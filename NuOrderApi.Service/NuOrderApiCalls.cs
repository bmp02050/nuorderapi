using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
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
            string url = $"{_baseUrl}order/{id}";
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
        
        public Order GetOrderByNumber(string id)
        {
            string url = $"{_baseUrl}order/number/{id}";
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
        public List<Order> GetOrdersByStatus(string status)
        {
            bool validStatus = false;
            Type type = typeof(OrderStatus); // MyClass is static class with static properties
            foreach (var p in type.GetFields( System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
            {
                var v = p.GetValue(null); // static classes cannot be instanced, so use null...
                if (status == v)
                {
                    validStatus = true;
                    break;
                }
            }
            if (!validStatus)
                throw new WebException($"{status} is not a valid status");
            string url = $"{_baseUrl}orders/{status}/detail";
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

            return JsonConvert.DeserializeObject<List<Order>>(result);
        }
    }
}