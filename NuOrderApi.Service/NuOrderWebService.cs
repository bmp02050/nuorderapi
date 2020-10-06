using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using NuOrder.Util;

namespace NuOrderApi.Service
{
    public class NuOrderWebService
    {
        private const string Characters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private readonly NuOrderConfig _configuration;

        private bool _isInitRequest;
        private bool _isVerifyRequest;

        private readonly Random _rnd = new Random();

        public NuOrderWebService(NuOrderConfig configuration)
        {
            _configuration = configuration;
        }

        private string Timestamp { get; set; }
        private string Nonce { get; set; }
        private string Signature { get; set; }

        private string Callback { get; set; }
        private string ApplicationName { get; set; }
        private string VerificationCode { get; set; }

        /* PUBLIC METHODS */

        public HttpWebResponse ExecuteRequest(string requestMethod, string endPoint)
        {
            return ExecuteRequest(requestMethod, endPoint, null);
        }

        public HttpWebResponse ExecuteRequest(string requestMethod, string endPoint, string data)
        {
            try
            {
                Nonce = GenerateNonce();
                Timestamp = GenerateTimestamp().ToString();
                Signature = GenerateSignature(requestMethod, endPoint);

                var req = (HttpWebRequest) WebRequest.Create(endPoint);

                var authorizationHeader = "OAuth ";
                foreach (var header in GetRequestHeaders())
                    authorizationHeader += header.Key + "=\"" + header.Value + "\",";
                
                authorizationHeader = authorizationHeader.Substring(0, authorizationHeader.Length - 1);
                
                req.Headers.Add(HttpRequestHeader.Authorization, authorizationHeader);
                req.Method = requestMethod;

                if ((requestMethod == "POST" || requestMethod == "PUT") && data != null)
                {
                    req.ContentType = "application/json";

                    using var writer = new StreamWriter(req.GetRequestStream());
                    writer.Write(data);
                }

                var response = (HttpWebResponse) req.GetResponse();

                return response;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }

        public void SetInitRequest(string applicationName, string callback)
        {
            _isInitRequest = true;
            ApplicationName = applicationName;
            Callback = callback;
        }

        public void SetVerifyRequest(string verificationCode)
        {
            _isVerifyRequest = true;
            VerificationCode = verificationCode;
        }

        /* SUPPORT METHODS */

        private Dictionary<string, string> GetRequestHeaders()
        {
            var headers = new Dictionary<string, string>();
            headers.Add("oauth_token", _configuration.Token);
            headers.Add("oauth_consumer_key", _configuration.ConsumerKey);
            headers.Add("oauth_timestamp", Timestamp);
            headers.Add("oauth_nonce", Nonce);
            headers.Add("oauth_version", _configuration.Version);
            headers.Add("oauth_signature_method", _configuration.SignatureMethod);
            headers.Add("oauth_signature", Signature);

            if (_isInitRequest)
            {
                headers.Add("oauth_callback", Callback);
                headers.Add("application_name", ApplicationName);
            }

            if (_isVerifyRequest)
                headers.Add("oauth_verifier", VerificationCode);

            return headers;
        }

        private string GenerateNonce()
        {
            var buffer = new char[16];
            for (var i = 0; i < 16; i++)
                buffer[i] = Characters[_rnd.Next(Characters.Length)];
            return new string(buffer);
        }

        private int GenerateTimestamp()
        {
            var span = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1, 0, 0, 0));
            return Convert.ToInt32(span.TotalSeconds);
        }

        private string GenerateSignature(string requestMethod, string endPoint)
        {
            var baseSignatureString = requestMethod + endPoint +
                                      "?oauth_consumer_key=" + _configuration.ConsumerKey + "&" +
                                      "oauth_token=" + _configuration.Token + "&" +
                                      "oauth_timestamp=" + Timestamp + "&" +
                                      "oauth_nonce=" + Nonce + "&" +
                                      "oauth_version=" + _configuration.Version + "&" +
                                      "oauth_signature_method=" + _configuration.SignatureMethod;

            if (_isInitRequest) baseSignatureString += "&oauth_callback=" + Callback;
            if (_isVerifyRequest) baseSignatureString += "&oauth_verifier=" + VerificationCode;

            var key = _configuration.ConsumerSecret + "&" + _configuration.TokenSecret;

            return GenerateSha1Hash(key, baseSignatureString);
        }

        private string GenerateSha1Hash(string key, string value)
        {
            var keyBytes = ConvertStringToByteArray(key);
            var valueBytes = ConvertStringToByteArray(value);
            byte[] hash = null;
            using (var hmac = new HMACSHA1(keyBytes))
            {
                hash = hmac.ComputeHash(valueBytes);
            }

            return ConvertByteArrayToHexString(hash);
        }

        private byte[] ConvertStringToByteArray(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        private string ConvertByteArrayToHexString(byte[] bytes)
        {
            var hex = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}