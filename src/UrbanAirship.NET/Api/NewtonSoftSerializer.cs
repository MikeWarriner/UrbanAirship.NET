using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp.Deserializers;
using System.Globalization;
using Newtonsoft.Json;
using RestSharp;

namespace UrbanAirship.NET.Api
{
    public class NewtonsoftDeserializer : IDeserializer
    {
        public NewtonsoftDeserializer()
        {
            Culture = CultureInfo.InvariantCulture;
        }

        public CultureInfo Culture { get; set; }
        public string DateFormat { get; set; }
        public string Namespace { get; set; }public string RootElement { get; set; }

        public T Deserialize<T>(RestResponse response) where T : new()
        {
            string contentType = response.ContentType;
            if (contentType.Contains(";")) contentType = contentType.Substring(0, contentType.IndexOf(";")).Trim();
            if (contentType == "application/json")
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            else
                throw new Exception("unknown content type '" + response.ContentType + "'");
        }
    }
}
