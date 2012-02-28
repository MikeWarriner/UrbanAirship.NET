using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace UrbanAirship.NET.Schema
{
    [DataContract]
    public class IOSDeviceTokenCountResponse
    {
        [DataMember(Name = "device_tokens_count")]
        public int DeviceTokenCount { get; set; }

        [DataMember(Name = "active_device_tokens_count")]
        public int ActiveDeviceCount { get; set; }
    }

    [DataContract]
    public class IOSDeviceTokenReportResponse
    {
        [DataMember(Name = "device_tokens_count")]
        public int DeviceTokenCount { get; set; }

        [DataMember(Name = "active_device_tokens_count")]
        public int ActiveDeviceCount { get; set; }

        [DataMember(Name = "current_page")]
        public int CurrentPage { get; set; }

        [DataMember(Name = "num_pages")]
        public int NumberOfPages { get; set; }

        [DataMember(Name = "device_tokens")]
        public List<DeviceTokenReportDetail> DeviceTokens { get; set; }

        [DataContract]
        public class DeviceTokenReportDetail
        {
            [DataMember(Name = "device_token")]
            public string DeviceToken { get; set; }

            [DataMember(Name = "active")]
            public bool IsActive { get; set; }

            [DataMember(Name = "alias")]
            public string Alias { get; set; }

            [DataMember(Name = "last_registration")]
            [JsonConverter(typeof(ISO8601Time))]
            public DateTime LastRegistration { get; set; }
        }
    }
}