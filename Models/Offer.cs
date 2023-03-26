using System.Collections.Generic;
using System.Xml;

namespace App1.Models
{
	internal class Offer
	{
		public int Id { get; set; }
		public string Type { get; set; }
		public int Bid { get; set; }
		public int? Cbid { get; set; }
		public bool avaliable { get; set; }
		public List<KeyValuePair<string, string>> Children { get; set; }
	}
}