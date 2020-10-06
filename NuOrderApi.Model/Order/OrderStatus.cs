namespace NuOrderApi.Model.Order
{
    public static class OrderStatus
    {
        public static string Draft = "draft"; 
        public static string Review = "review"; 
        public static string Pending = "pending"; 
        public static string Approved = "approved"; 
        public static string Processed = "processed"; 
        public static string Shipped = "shipped"; 
        public static string Cancelled = "cancelled";
    }
}