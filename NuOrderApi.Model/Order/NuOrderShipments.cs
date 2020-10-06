using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NuOrderApi.Model.Order
{
    [Serializable]
    public class NuOrderShipments
    {
        [JsonProperty("type")]
        public string ShippingType { get; set; }
        [JsonProperty("tracking_numbers")]
        public List<string> TrackingNumbers { get; set; }
        [JsonProperty("line_items")]
        public List<NuOrderLine> LineItems { get; set; }

        public NuOrderShipments()
        {
            TrackingNumbers = new List<string>();
            LineItems = new List<NuOrderLine>();
        }
    }
}