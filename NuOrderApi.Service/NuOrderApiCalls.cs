using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using NuOrderApi.Model.Order;

namespace NuOrderApi.Service
{
    public class NuOrderApiCalls
    {
        private readonly NuOrderWebService _nuOrderWebService;
        private readonly string _baseUrl;

        public NuOrderApiCalls(NuOrderWebService nuOrderWebService)
        {
            _nuOrderWebService = nuOrderWebService;
            _baseUrl = "https://nuorder.com/api/";
        }

        public Order GetOrderById(string id)
        {
            var url = $"{_baseUrl}order/{id}";
            var result = string.Empty;

            using (var response = _nuOrderWebService.ExecuteRequest("GET", url))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Order>(result);
        }

        public Order GetOrderByNumber(string id)
        {
            var url = $"{_baseUrl}order/number/{id}";
            var result = string.Empty;

            using (var response = _nuOrderWebService.ExecuteRequest("GET", url))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Order>(result);
        }

        public List<Order> GetOrdersByStatus(string status)
        {
            var validStatus = IsStatusValid(status);
            if (!validStatus)
                throw new WebException($"{status} is not a valid status");
            var url = $"{_baseUrl}orders/{status}/detail";
            var result = string.Empty;

            using (var response = _nuOrderWebService.ExecuteRequest("GET", url))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<List<Order>>(result);
        }

        public List<string> GetOrderListByStatus(string status)
        {
            var validStatus = IsStatusValid(status);
            if (!validStatus)
                throw new WebException($"{status} is not a valid status");
            var url = $"{_baseUrl}orders/{status}/list";
            var result = string.Empty;

            using (var response = _nuOrderWebService.ExecuteRequest("GET", url))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<List<string>>(result);
        }

        public Order PutNewOrder(Order order)
        {
            var url = $"{_baseUrl}order/new";
            var result = string.Empty;

            using (var response = _nuOrderWebService.ExecuteRequest("PUT", url, SerializeOrder(order)))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Order>(result);
        }
        public Order UpdateOrderById(string id, Order order)
        {
            var url = $"{_baseUrl}order/{id}";
            var result = string.Empty;

            using (var response = _nuOrderWebService.ExecuteRequest("POST", url, SerializeOrder(order)))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Order>(result);
        }
        public Order UpdateOrderByNumber(string number, Order order)
        {
            var url = $"{_baseUrl}order/{number}";
            var result = string.Empty;

            using (var response = _nuOrderWebService.ExecuteRequest("POST", url, SerializeOrder(order)))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Order>(result);
        }
        public Order UpdateOrderStatusById(string id, string status)
        {
            if (!IsStatusValid(status))
                throw new WebException("Invalid Status");
            
            var url = $"{_baseUrl}order/{id}/{status}";
            var result = string.Empty;

            using (var response = _nuOrderWebService.ExecuteRequest("POST", url))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Order>(result);
        }
        
        public Order UpdateOrderStatusByNumber(string number, string status)
        {
            if (!IsStatusValid(status))
                throw new WebException("Invalid Status");
            
            var url = $"{_baseUrl}order/number/{number}/{status}";
            var result = string.Empty;

            using (var response = _nuOrderWebService.ExecuteRequest("POST", url))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Order>(result);
        }
        
        //TODO: Find out if patch fields can be used on objects, shows only External_Id as available field to patch
        //TODO: Patch Order Field By Id
        //TODO: Patch Order Field By Status
        
        #region Validation

        private bool IsStatusValid(string status)
        {
            var type = typeof(OrderStatus); // MyClass is static class with static properties
            foreach (var p in type.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                var v = p.GetValue(null); // static classes cannot be instanced, so use null...
                if (status == v) return true;
            }

            return false;
        }

        private string SerializeOrder(Order order)
        {
            try
            {
                return JsonConvert.SerializeObject(order);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion
    }
}