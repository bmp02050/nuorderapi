namespace NuOrder.Util
{
    public class NuOrderConfig
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string Token { get; set; }
        public string TokenSecret { get; set; }
        public string Version { get; set; }
        public string SignatureMethod { get; set; }

        public NuOrderConfig()
        {
            
        }
    }
}