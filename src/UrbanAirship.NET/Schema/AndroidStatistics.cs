using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace UrbanAirship.NET.Schema
{
    [DataContract]
    public class AndroidDeviceTokenCountResponse
    {
        [DataMember(Name = "device_tokens_count")]
        public int DeviceTokenCount { get; set; }

        [DataMember(Name = "active_device_tokens_count")]
        public int ActiveDeviceCount { get; set; }
    }

    [DataContract]
    public class AndroidDeviceTokenReportResponse
    {
        [DataMember(Name = "next_page")]
        public string NextPage { get; set; }

        [DataMember(Name = "apids")]
        public List<DeviceTokenReportDetail> APIDS { get; set; }

        [DataContract]
        public class DeviceTokenReportDetail
        {
            [DataMember(Name = "apid")]
            public string DeviceToken { get; set; }

            [DataMember(Name = "active")]
            public bool IsActive { get; set; }

            [DataMember(Name = "alias")]
            public string Alias { get; set; }

            [DataMember(Name = "tags")]
            public string[] Tags{ get; set; }

            /*
            [DataMember(Name = "last_registration")]
            [JsonConverter(typeof(ISO8601Time))]
            public DateTime LastRegistration { get; set; }
             * */
        }
    }
}