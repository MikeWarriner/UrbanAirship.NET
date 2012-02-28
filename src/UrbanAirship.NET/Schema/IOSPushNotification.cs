using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace UrbanAirship.NET.Schema
{
    [DataContract]
    public class IOSBatchPushNotificationRequest : List<IOSPushNotificationRequest>
    {
    }

    [DataContract]
    public class IOSBroadcastRequest
    {
        [DataMember(Name = "aps")]
        public IOSAPSBody APS { get; set; }
    
        [DataMember(Name = "exclude_tokens")]
        public List<string> ExcludeTokens { get; set; }
        
    }

    [DataContract(Name = "apsNotification")]
    public class IOSPushNotificationRequest
    {
        [DataMember(Name = "device_tokens")]
        public List<string> DeviceTokens { get; set; }

        [DataMember(Name = "aliases")]
        public List<string> Aliases { get; set; }

        [DataMember(Name = "alias")]
        public string Alias { get; set; }


        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }

        [DataMember(Name = "schedule_for")]
        [JsonConverter(typeof(ISO8601Time))]
        public DateTime[] ScheduleFor { get; set; }


        [DataMember(Name = "exclude_tokens")]
        public List<string> ExcludeTokens { get; set; }
        
        [DataMember(Name = "aps")]
        public IOSAPSBody APS { get; set; }
    }
    [DataContract(Name = "apsBody")]
    public class IOSAPSBody
    {
        [DataMember(Name = "badge")]
        public string Badge { get; set; }

        [DataMember(Name = "alert")]
        public string Alert { get; set; }

        [DataMember(Name = "sound")]
        public string Sound { get; set; }

    }


    [DataContract]
    public class IOSScheduledPushNotificationRequest
    {
        [DataMember(Name = "alias")]
        public string Alias { get; set; }

        [DataMember(Name = "schedule_for")]
        [JsonConverter(typeof(ISO8601Time))]
        public DateTime Time { get; set; }

        [DataMember(Name = "payload")]
        public IOSPushNotificationRequest APS { get; set; }
    }


    [DataContract]
    public class IOSCancelPushNotificationRequest
    {
        [DataMember(Name = "cancel")]
        public List<string> CancelByScheduledNotificationUrls { get; set; }

        
        [DataMember(Name = "cancel_aliases")]
        public List<string> CancelByAliases { get; set; }

        [DataMember(Name = "cancel_device_tokens")]
        public List<string> CancelByDeviceTokens { get; set; }
    }

    [DataContract]
    public class IOSPushNotificationResponse
    {
        [DataMember(Name="scheduled_notifications")]
        public string[] ScheduledNotificationUrls { get; set; }
    }
}