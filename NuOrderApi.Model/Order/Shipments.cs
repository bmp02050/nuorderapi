using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NuOrderApi.Model.Order
{
    [Serializable]
    public class Shipments
    {
        [JsonProperty("type")]
        public string ShippingType { get; set; }
        [JsonProperty("tracking_numbers")]
        public List<string> TrackingNumbers { get; set; }
        [JsonProperty("line_items")]
        public List<Line> LineItems { get; set; }

        public Shipments()
        {
            TrackingNumbers = new List<string>();
            LineItems = new List<Line>();
        }
    }
}