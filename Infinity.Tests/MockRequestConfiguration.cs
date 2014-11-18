using System;
using System.Reflection;

using RestSharp;
using RestSharp.Serializers;

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
        public string RequestBody { get; set; }
        public object RequestObject
        {
            set
            {
                RequestBody = new JsonSerializer().Serialize(value);
            }
        }
        public string ResponseBody { get; set; }
        public string ResponseResource
        {
            set
            {
                string resourceName = value.Replace('.', '_');

                PropertyInfo resourceProperty = typeof(Properties.Resources).GetProperty(resourceName, BindingFlags.Static | BindingFlags.NonPublic);

                if (resourceProperty == null)
                {
                    throw new Exception(String.Format("Could not load resource {0}", resourceName));
                }

                byte[] resourceData = (byte[])resourceProperty.GetValue(null);
                ResponseBody = System.Text.Encoding.UTF8.GetString(resourceData);
            }
        }
    }
}