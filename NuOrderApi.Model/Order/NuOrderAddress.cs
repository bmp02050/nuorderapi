using System;
using Newtonsoft.Json;

namespace NuOrderApi.Model.Order
{
    [Serializable]
    public class NuOrderAddress
    {
        [JsonProperty("code")]
        public string Code {get;set;}
        [JsonProperty("line_1")]
        public string Line1{get;set;}
        [JsonProperty("line_2")]
        public string Line2{get;set;}
        [JsonProperty("city")]
        public string City {get;set;}
        [JsonProperty("state")]
        public string State {get;set;}
        [JsonProperty("zip")]
        public string Zipcode{get;set;}
        [JsonProperty("country")]
        public string Country {get;set;}

        public NuOrderAddress()
        {
            
        }
    }
}