using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace UrbanAirship.NET.Schema
{
    [DataContract]
    public class Tags
    {
        [DataMember]
        public string[] tag { get; set; }
    }
    [DataContract]
    public class QuietTime
    {
        [DataMember(Name="start")]
        public string Start { get; set; }
        [DataMember(Name="end")]
        public string End { get; set; }
    }
    [DataContract]
    public class AndroidDeviceTokenRegistrationInfo
    {
        [DataMember(Name="alias")]
        public string Alias { get; set; }
        [DataMember(Name = "tags")]
        public string[] Tags { get; set; }
        [DataMember(Name = "badge")]
        public string Badge { get; set; }
        [DataMember(Name = "quiettime")]
        public QuietTime QuietTime { get; set; }
        [DataMember(Name = "tz")]
        public string TimeZone { get; set; }
    }
    [DataContract]
    public class IOSDeviceTokenRegistrationInfo
    {
        [DataMember(Name = "alias")]
        public string Alias { get; set; }
        [DataMember(Name = "tags")]
        public string[] Tags { get; set; }
        [DataMember(Name = "badge")]
        public string Badge { get; set; }
        [DataMember(Name = "quiettime")]
        public QuietTime QuietTime { get; set; }
        [DataMember(Name = "tz")]
        public string TimeZone { get; set; }
    }
}
