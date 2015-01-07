using System;
using System.Collections.Generic;
using System.Linq;
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

                IEnumerable<PropertyInfo> resourceProperties = typeof(Properties.Resources).GetTypeInfo().DeclaredProperties.Where(m => (m.Name.Equals(resourceName)));

                if (resourceProperties.Count() != 1)
                {
                    throw new Exception(String.Format("Could not load resource {0}", resourceName));
                }

                PropertyInfo resourceProperty = resourceProperties.First();
                this.ResponseBody = (string)resourceProperty.GetValue(null);
            }
        }
    }
}