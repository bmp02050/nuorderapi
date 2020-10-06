using System;
using System.Collections.Generic;
using System.Net;
using NuOrder.Util;
using NuOrderApi.Model.Order;
using NuOrderApi.Service;
using Xunit;

namespace NuOrderApi.Test.Order
{
    public class OrdersTest
    {
        private NuOrderConfig _nuOrderConfig;
        private NuOrderWebService _nuOrderWebService;
        private NuOrderApiCalls _nuOrderApiCalls;
        public OrdersTest()
        {
            _nuOrderConfig = new NuOrderConfig()
            {
                ConsumerKey = Environment.GetEnvironmentVariable("NUORDERCONSUMERKEY"),
                ConsumerSecret = Environment.GetEnvironmentVariable("NUORDERCONSUMERSECRET"),
                Token = Environment.GetEnvironmentVariable("NUORDERTOKEN"),
                TokenSecret = Environment.GetEnvironmentVariable("NUORDERTOKENSECRET"),
                Version = "1.0",
                SignatureMethod = "HMAC-SHA1"
            };
            _nuOrderWebService = new NuOrderWebService(_nuOrderConfig);
            _nuOrderApiCalls = new NuOrderApiCalls(_nuOrderWebService);
        }

        [Fact]
        public void ShouldGetOrderById()
        {
            try
            {
                Model.Order.Order order = _nuOrderApiCalls.GetOrderById("5f713e54495bf661cb1d55bd");
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
            
        }
        
        [Fact]
        public void ShouldThrowExceptionGetOrderById()
        {
            Assert.Throws<WebException>(() =>  _nuOrderApiCalls.GetOrderById("cheese"));
        }
        
        [Fact]
        public void ShouldGetOrderByNumber()
        {
            try
            {
                Model.Order.Order order = _nuOrderApiCalls.GetOrderByNumber("60396810");
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
            
        }
        
        [Fact]
        public void ShouldThrowExceptionGetOrderByNumber()
        {
            Assert.Throws<WebException>(() =>  _nuOrderApiCalls.GetOrderByNumber("cheese"));
        }
        
        [Fact]
        public void ShouldGetOrdersByStatus()
        {
            try
            {
                List<Model.Order.Order> orders = _nuOrderApiCalls.GetOrdersByStatus(OrderStatus.Draft);
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
            
        }
        
        [Fact]
        public void ShouldThrowExceptionGetOrdersByStatus()
        {
            Assert.Throws<WebException>(() =>  _nuOrderApiCalls.GetOrdersByStatus("cheese"));
        }
    }
}