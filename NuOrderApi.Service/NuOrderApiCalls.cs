using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Net;
using System.Reflection;
using Newtonsoft.Json;
using NuOrderApi.Model.BuyerCollection;
using NuOrderApi.Model.CatalogCollection;
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

        #region Buyer Collection
        public Buyer AddBuyerToCompanyById(string id, Buyer buyer)
        {
            var url = $"{_baseUrl}company/{id}/add/buyer";
            var result = string.Empty;
            
            using (var response = _nuOrderWebService.ExecuteRequest("PUT", url, SerializeObject(buyer)))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Buyer>(result);
        }
        
        public Buyer AddBuyerToCompanyByCompanyCode(string companyCode, Buyer buyer)
        {
            var url = $"{_baseUrl}company/code/{companyCode}/add/buyer";
            var result = string.Empty;
            
            using (var response = _nuOrderWebService.ExecuteRequest("PUT", url, SerializeObject(buyer)))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Buyer>(result);
        }
        
        public Buyer UpdateBuyerByCompanyId(string id, Buyer buyer)
        {
            var url = $"{_baseUrl}company/{id}/update/buyer/{buyer.Email}";
            var result = string.Empty;
            
            using (var response = _nuOrderWebService.ExecuteRequest("POST", url, SerializeObject(buyer)))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Buyer>(result);
        }
        
        public Buyer UpdateBuyerByCompanyCode(string companyCode, Buyer buyer)
        {
            var url = $"{_baseUrl}company/code/{companyCode}/update/buyer/{buyer.Email}";
            var result = string.Empty;
            
            using (var response = _nuOrderWebService.ExecuteRequest("POST", url, SerializeObject(buyer)))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Buyer>(result);
        }

        public Buyer DeleteBuyerByCompanyId(string id, Buyer buyer)
        {
            var url = $"{_baseUrl}company/{id}/buyer/{buyer.Email}";
            var result = string.Empty;
            
            using (var response = _nuOrderWebService.ExecuteRequest("DELETE", url))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Buyer>(result);
        }
        
        public Buyer DeleteBuyerByCompanyCode(string companyCode, Buyer buyer)
        {
            var url = $"{_baseUrl}company/code/{companyCode}/buyer/{buyer.Email}";
            var result = string.Empty;
            
            using (var response = _nuOrderWebService.ExecuteRequest("DELETE", url))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Buyer>(result);
        }
        public Buyer DeleteAllBuyerByCompanyId(string id)
        {
            var url = $"{_baseUrl}company/{id}/buyers";
            var result = string.Empty;
            
            using (var response = _nuOrderWebService.ExecuteRequest("DELETE", url))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Buyer>(result);
        }
        
        public Buyer DeleteAllBuyerByCompanyCode(string companyCode)
        {
            var url = $"{_baseUrl}company/code/{companyCode}/buyers";
            var result = string.Empty;
            
            using (var response = _nuOrderWebService.ExecuteRequest("DELETE", url))
            {
                if (response != null)
                {
                    using var reader = new StreamReader(response.GetResponseStream() ??
                                                        throw new WebException("GetResponseStream failed"));
                    result = reader.ReadToEnd();
                }
            }

            return JsonConvert.DeserializeObject<Buyer>(result);
        }
        
        #endregion
        #region Order Collection
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

        public Order GetOrderByNumber(string number)
        {
            var url = $"{_baseUrl}order/number/{number}";
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

            using (var response = _nuOrderWebService.ExecuteRequest("PUT", url, SerializeObject(order)))
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

            using (var response = _nuOrderWebService.ExecuteRequest("POST", url, SerializeObject(order)))
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

            using (var response = _nuOrderWebService.ExecuteRequest("POST", url, SerializeObject(order)))
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

        private string SerializeObject<T>(T @object)
        {
            try
            {
                return JsonConvert.SerializeObject(@object);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        #endregion
        #endregion

        #region Catalog Collection

        //TODO Create Catalog Collection

        #endregion
        
        
    }
}