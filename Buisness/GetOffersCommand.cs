using App1.Mappers;
using App1.Models;
using Java.Util;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using System.Text;
using System.IO;
using App1.Mappers.Interfaces;

namespace App1.Buisness
{
	internal class GetOffersCommand : IGetOffersCommand
	{
		private readonly IOfferMapper _mapper;

		public GetOffersCommand(IOfferMapper mapper)
		{
			_mapper = mapper;
		}

		public async Task<List<Offer>> ExecuteAsync()
		{
			using (var client = new HttpClient())
			{
				var response = await client.GetAsync("http://partner.market.yandex.ru/pages/help/YML.xml");
				Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

				if (!response.IsSuccessStatusCode)
				{
					return null;
				}
				
				XmlDocument xmlDocument = new XmlDocument();
				StreamReader sr = new StreamReader(await response.Content.ReadAsStreamAsync(), Encoding.GetEncoding("windows-1251"));
				xmlDocument.LoadXml(sr.ReadToEnd());
				var nodes = xmlDocument.GetElementsByTagName("offer");
				List<Offer> offers = new List<Offer>();

				foreach (XmlNode node in nodes)
				{
					offers.Add(_mapper.Map(node));
				}

				return offers;
			}
		}
	}
}