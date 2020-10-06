using System;
using Newtonsoft.Json;

namespace NuOrderApi.Model.CatalogCollection
{
    [Serializable]
    public class Entry
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        
    }
    
}