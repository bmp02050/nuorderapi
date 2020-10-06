using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NuOrderApi.Model.Order
{
    [Serializable]
    public class Order
    {
        [JsonProperty("order_number")] public string OrderNumber { get; set; }

        [JsonProperty("external_id")] public string ExternalId { get; set; }

        [JsonProperty("customer_po_number")] public string CustomerPoNumber { get; set; }

        [JsonProperty("currency_code")] public string CurrencyCode { get; set; }

        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("discount")] public decimal Discount { get; set; }
        [JsonProperty("start_ship")] public string StartShip { get; set; }

        [JsonProperty("end_ship")]
        public string EndShip { get; set; }
        [JsonProperty("rep_code")]
        public string RepCode { get; set; }
        [JsonProperty("rep_email")]
        public string RepEmail { get; set; }
        [JsonProperty("notes")]
        public string Notes { get; set; }
        [JsonProperty("billing_address")]
        public NuOrderAddress BillingAddress { get; set; }
        [JsonProperty("shipping_address")]
        public NuOrderAddress ShippingAddress { get; set; }
        [JsonProperty("retailer")]
        public NuOrderRetailer Retailer { get; set; }
        [JsonProperty("line_items")]
        public List<NuOrderLine> LineItems { get; set; }
        [JsonProperty("total")]
        public decimal Total { get; set; }
        [JsonProperty("shipments")]
        public List<NuOrderShipments> Shipments { get; set; }

        [JsonProperty("created_on")]
        public string CreatedOn { get; set; }
        
        [JsonProperty("discounted_total")]
        public string DiscountedTotal { get; set; }
        public Order()
        {
            LineItems = new List<NuOrderLine>();
            Shipments = new List<NuOrderShipments>();
        }
        
        
    }

   
}