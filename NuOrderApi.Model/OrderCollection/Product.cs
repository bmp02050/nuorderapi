using System;
using Newtonsoft.Json;

namespace NuOrderApi.Model.Order
{
    [Serializable]
    public class Product
    {
        [JsonProperty("brand_id")]
        public string BrandId { get; set; }
        [JsonProperty("season")]
        public string Season { get; set; }
        [JsonProperty("style_number")]
        public string StyleNumber{ get; set; }
        [JsonProperty("color")]
        public string Color { get; set; }
        [JsonProperty("pop")]
        public string Pop { get; set; }

        public Product()
        {
            
        }
    }
}