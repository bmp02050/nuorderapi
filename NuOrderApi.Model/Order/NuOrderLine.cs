using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NuOrderApi.Model.Order
{
    [Serializable]
    public class NuOrderLine
    {
        [JsonProperty("product")]
        public NuOrderProduct Product { get; set; }
        [JsonProperty("discount")]
        public decimal Discount { get; set; }
        [JsonProperty("ship_start")]
        public string ShipStart { get; set; }
        [JsonProperty("ship_end")]
        public string ShipEnd { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("warehouse")]
        public string Warehouse { get; set; }
        [JsonProperty("sizes")]
        public List<NuOrderSizes> Sizes { get; set; }
        [JsonProperty("prebook")]
        public bool Prebook { get; set; }

        public NuOrderLine()
        {
            Sizes = new List<NuOrderSizes>();
        }
    }
}