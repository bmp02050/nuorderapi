using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NuOrderApi.Model.BuyerCollection
{
    [Serializable]
    public class Buyer
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("reps")]
        public List<string> Reps { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("phone_office")]
        public string PhoneOffice { get; set; }
        
        [JsonProperty("phone_cell")]
        public string PhoneCell { get; set; }

        public Buyer()
        {
            Reps = new List<string>();
        }
        
        
    }
}