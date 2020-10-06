using System;
using System.Reflection;
using Newtonsoft.Json;

namespace NuOrderApi.Model.CatalogCollection
{
    [Serializable]
    public class Restrictions
    {
        [JsonProperty("sync_id")]
        public string SyncId { get; set; }
        
        [JsonProperty("field")]
        public string Field { get; set; }
        
        [JsonProperty("value")]
        public string Value { get; set; }
          
    }
}