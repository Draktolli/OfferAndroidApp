using App1.Mappers.Interfaces;
using App1.Models;
using System.Collections.Generic;
using System.Xml;

namespace App1.Mappers
{
	internal class OfferMapper : IOfferMapper
	{
		public Offer Map(XmlNode node)
		{
			List<KeyValuePair<string, string>> childinfo = new List<KeyValuePair<string, string>>();

			foreach (XmlNode childNode in node.ChildNodes)
			{
				childinfo.Add(new KeyValuePair<string, string>(childNode.Name, childNode.InnerText));
			}

			return new Offer
			{
				Id = int.Parse(node.Attributes["id"].Value),
				Type = node.Attributes["type"].Value,
				Bid = int.Parse(node.Attributes["bid"].Value),
				Cbid = int.TryParse(node.Attributes["cbid"]?.Value, out int val) ? val : default,
				avaliable = bool.Parse(node.Attributes["available"].Value),
				Children = childinfo
			};
		}
	}
}