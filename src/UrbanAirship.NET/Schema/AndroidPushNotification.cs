using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace UrbanAirship.NET.Schema
{
    [DataContract]
    public class AndroidBatchPushNotificationRequest : List<AndroidPushNotificationRequest>
    {
    }

    [DataContract]
    public class AndroidBroadcastRequest
    {
        [DataMember(Name = "android")]
        public AndroidAPSBody APS { get; set; }
    }

    [DataContract(Name = "apsNotification")]
    public class AndroidPushNotificationRequest
    {
        [DataMember(Name = "apids")]
        public List<string> APIDS { get; set; }

        [DataMember(Name = "aliases")]
        public List<string> Aliases { get; set; }

        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }

        [DataMember(Name = "android")]
        public AndroidAPSBody APS { get; set; }
    }
    [DataContract(Name = "apsBody")]
    public class AndroidAPSBody
    {
        [DataMember(Name = "alert")]
        public string Alert { get; set; }
    }
}