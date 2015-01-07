using System;
using System.Net.Http;
using System.Reflection;
using Newtonsoft.Json;

namespace Infinity.Tests
{
    public class MockHttpMessageConfiguration
    {
        public MockHttpMessageConfiguration()
        {
            Method = HttpMethod.Get;
        }

        public HttpMethod Method { get; set; }
        public string Uri { get; set; }
        public string RequestBody { get; set; }
        public object RequestObject
        {
            set
            {
                RequestBody = JsonConvert.SerializeObject(value);
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