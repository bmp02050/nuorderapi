using System;
using Newtonsoft.Json;

namespace NuOrderApi.Model.Order
{
    [Serializable]
    public class NuOrderSizes
    {
        [JsonProperty("size")]
        public string Size {get;set;}
        [JsonProperty("upc")]
        public string Upc {get;set;}
        [JsonProperty("quantity")]
        public int Quantity {get;set;}
        [JsonProperty("price")]
        public decimal Price {get;set;}
        [JsonProperty("original_price")]
        public decimal OriginalPrice{get;set;}

        public NuOrderSizes()
        {
            
        }
        
    }
}