using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NuOrderApi.Model.CatalogCollection
{
    [Serializable]
    public class Catalog
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("sync_id")]
        public string SyncId { get; set; }
        
        [JsonProperty("brand_id")]
        public string BrandId { get; set; }
        
        [JsonProperty("created_on")]
        public int? CreatedOn { get; set; }

        [JsonProperty("modified_on")] 
        public int? ModifiedOn { get; set; }
        
        [JsonProperty("owner_account_id")]
        public string OwnerAccountId { get; set; }
        
        [JsonProperty("active")]
        public bool Active { get; set; }
        
        [JsonProperty("archived")]
        public bool Archived { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("cover")]
        public string Cover { get; set; }
        
        [JsonProperty("portrait_image")]
        public string PortraitImage { get; set; }
        
        [JsonProperty("default_pdf_template")]
        public string DefaultPdfTemplate { get; set; }
        
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("restrictions")]
        public List<Restrictions> Restrictions { get; set; }
        
        [JsonProperty("sort")]
        public int? Sort { get; set; }
        

    }
}