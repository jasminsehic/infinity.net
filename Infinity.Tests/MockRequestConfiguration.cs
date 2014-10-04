using System;
using System.Reflection;

using RestSharp;

namespace Infinity.Tests
{
    public class MockRequestConfiguration
    {
        public MockRequestConfiguration()
        {
            Method = Method.GET;
        }

        public Method Method { get; set; }
        public string Uri { get; set; }
        public string Response { get; set; }
        public string ResponseResource
        {
            set
            {
                string resourceName = value.Replace('.', '_');

                byte[] resourceData = (byte[])typeof(Properties.Resources).GetProperty(resourceName, BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
                Response = System.Text.Encoding.UTF8.GetString(resourceData);
            }
        }
    }
}
