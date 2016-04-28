using System;
using Newtonsoft.Json;

namespace RealEstater
{
	public class House
	{
		[JsonProperty(PropertyName = "listingID")]
		public int ListingID { get; set; }
		[JsonProperty(PropertyName = "image")]
		public string Image { get; set; }
		[JsonProperty(PropertyName = "address")]
		public string Address { get; set; }
		[JsonProperty(PropertyName = "beds")]
		public int Beds { get; set;}
		[JsonProperty(PropertyName = "baths")]
		public int Baths { get; set;}
		[JsonProperty(PropertyName = "features")]
		public string Features { get; set; }
		[JsonProperty(PropertyName = "estimatedValue")]
		public string EstimatedValue { get; set; }
		[JsonProperty(PropertyName = "changeOverLastYear")]
		public string ChangeOverLastYear { get; set; }
		[JsonProperty(PropertyName = "link")]
		public string Link { get; set; }
	};
}

