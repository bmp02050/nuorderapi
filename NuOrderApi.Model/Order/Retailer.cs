using System;
using Newtonsoft.Json;

namespace NuOrderApi.Model.Order
{
    [Serializable]
    public class Retailer
    {
        [JsonProperty("buyer_name")]
        public string BuyerName {get;set;}
        
        [JsonProperty("buyer_email")]
        public string BuyerEmail { get; set; }
        
        [JsonProperty("retailer_name")]
        public string RetailerName {get;set;}
        
        [JsonProperty("retailer_code")]
        public string RetailerCode { get; set; }
        

        public Retailer()
        {
            
        }
    }
}