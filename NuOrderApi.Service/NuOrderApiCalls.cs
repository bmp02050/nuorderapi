using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using NuOrder.Util;
using NuOrderApi.Model.Order;

namespace NuOrderApi.Service
{
    public class NuOrderApiCalls
    {
        private string _baseUrl;
        private readonly NuOrderWebService _nuOrderWebService;

        public NuOrderApiCalls(NuOrderWebService nuOrderWebService)
        {
            _nuOrderWebService = nuOrderWebService;
            _baseUrl = "https://nuorder.com/api/";
        }

        public Order GetOrderById(string id)
        {
            string url = $"{_baseUrl}/order/";
            string result = string.Empty;
            
            using (HttpWebResponse response = _nuOrderWebService.ExecuteRequest("GET", url))
            {
                if (response != null)
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }

            return JsonConvert.DeserializeObject<Order>(result);
        }
    }
}