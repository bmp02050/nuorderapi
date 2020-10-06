using Newtonsoft.Json;

namespace NuOrderApi.Model.CatalogCollection
{
    public class Item
    {
        [JsonProperty("style_number")]
        public string StyleNumber { get; set; }
        
    }
}