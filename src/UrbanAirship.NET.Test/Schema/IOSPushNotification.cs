using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrbanAirship.NET.Schema;
using Newtonsoft.Json;

namespace UrbanAirship.NET.Test
{
    
    [TestClass]
    public class PushNotificationTests
    {
        [TestMethod]
        public void TestSchemaIOSPushNotification()
        {
            string expected = ""+
            "{"+
    "\"device_tokens\": ["+
    "    \"some device token\","+
    "    \"another device token\""+
    "],"+
    "\"aliases\": ["+
    "    \"user1\","+
    "    \"user2\""+
    "],"+
    "\"tags\": ["+
    "    \"tag1\","+
    "    \"tag2\""+
    "],"+
    "\"schedule_for\": ["+
    "    \"2010-07-27 22:48:00\","+
    "    \"2010-07-28 22:48:00\""+
    "],"+
    "\"exclude_tokens\": ["+
    "    \"device token you want to skip\","+
    "    \"another device token you want to skip\""+
    "],"+
    "\"aps\": {"+
    "     \"badge\": \"10\","+
    "     \"sound\": \"cat.caf\""+
    "}}";

            var push = new IOSPushNotificationRequest()
            {
                Aliases = new List<string>() { "user1", "user2" },
                APS = new IOSAPSBody()
                {
                    Badge = "10",
                    Sound = "cat.caf"
                },
                ExcludeTokens = new List<string>() { "device token you want to skip", "another device token you want to skip" },
                Tags = new List<string>() { "tag1", "tag2" },
                DeviceTokens = new List<string>() { "some device token", "another device token" },
                /*
                ScheduleFor = //new PushNotification.ScheduleForBodyList() { 
                    new  UrbanAirship.NET.Schema.PushNotification.ScheduleForBody() { 
                        Time = DateTime.Parse("2010-07-27 22:48:00") 
                    }
                //}
                 * */
                ScheduleFor = new DateTime[] { DateTime.Parse("2010-07-27 22:48:00"), DateTime.Parse("2010-07-28 22:48:00") }
            };


            List<JsonConverter> converters = new List<JsonConverter>();
            //converters.Add(new SchedulerConverter());
            string serializedToken = Newtonsoft.Json.JsonConvert.SerializeObject(push, Newtonsoft.Json.Formatting.None,
                new Newtonsoft.Json.JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                 Converters = converters
            });
            Console.WriteLine("Serialized : " + serializedToken);

            Helper.AreJsonEqual(expected, serializedToken);



        }
        [TestMethod]
        public void TestSchemaIOSBroadcastMessage()
        {
            string expected = ""+
                "{"+
    "\"aps\": {"+
         "\"alert\": \"Hello from Urban Airship!\""+
    "}"+
"}";
            var push = new IOSBroadcastRequest()
            {
                APS = new IOSAPSBody()
                {
                    Alert = "Hello from Urban Airship!"
                }
            };


            List<JsonConverter> converters = new List<JsonConverter>();
            //converters.Add(new SchedulerConverter());
            string serializedToken = Newtonsoft.Json.JsonConvert.SerializeObject(push, Newtonsoft.Json.Formatting.None,
                new Newtonsoft.Json.JsonSerializerSettings()
                {
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    Converters = converters
                });
            Console.WriteLine("Serialized : " + serializedToken);

            Helper.AreJsonEqual(expected, serializedToken);

     
        }
        [TestMethod]
        public void TestSchemaIOSAutoUpdate()
        {
            string expected = ""+
            "{"+
     "\"alias\": \"foo\","+
     "\"aps\": {"+
         "\"badge\": \"auto\","+
         "\"alert\": \"My badge is now 4!\""+
    "}";

            var push = new IOSPushNotificationRequest()
            {
                Alias = "foo",
                APS = new IOSAPSBody()
                {
                    Badge = "auto",
                    Alert = "My badge is now 4!"
                },
            };


            List<JsonConverter> converters = new List<JsonConverter>();
            //converters.Add(new SchedulerConverter());
            string serializedToken = Newtonsoft.Json.JsonConvert.SerializeObject(push, Newtonsoft.Json.Formatting.None,
                new Newtonsoft.Json.JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                 Converters = converters
            });
            Console.WriteLine("Serialized : " + serializedToken);

            Helper.AreJsonEqual(expected, serializedToken);

        }
        [TestMethod]
        public void TestSchemaIOSScheduledNotificationResponse()
        {
            string expected = ""+
            "{"+
    "\"scheduled_notifications\": ["+
        "\"https://go.urbanairship.com/api/push/scheduled/XX\","+
        "\"https://go.urbanairship.com/api/push/scheduled/XY\""+
    "]"+
"}";

            var  response = new IOSPushNotificationResponse()
            {
                 ScheduledNotificationUrls = new string[]
                 {
        "https://go.urbanairship.com/api/push/scheduled/XX",
        "https://go.urbanairship.com/api/push/scheduled/XY"
            }
        };
            List<JsonConverter> converters = new List<JsonConverter>();
            //converters.Add(new SchedulerConverter());
            string serializedToken = Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.None,
                new Newtonsoft.Json.JsonSerializerSettings()
            {
                NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                 Converters = converters
            });
            Console.WriteLine("Serialized : " + serializedToken);

            Helper.AreJsonEqual(expected, serializedToken);

        }

        [TestMethod]
        public void TestSchemaIOSCancelRequest()
        {
            string expected = ""+
    "        {"+
    "\"cancel\": ["+
    "    \"https://go.urbanairship.com/api/push/scheduled/XX\","+
    "    \"https://go.urbanairship.com/api/push/scheduled/XY\""+
    "],"+
    "\"cancel_aliases\": ["+
    "    \"some_alias\","+
    "    \"another_alias\""+
    "],"+
    "\"cancel_device_tokens\": ["+
    "    \"example_device_token\","+
    "    \"other_example_device_token\""+
    "]"+
"}";


            var  response = new IOSCancelPushNotificationRequest()
            {
                CancelByScheduledNotificationUrls = new List<string>()
                 {
        "https://go.urbanairship.com/api/push/scheduled/XX",
        "https://go.urbanairship.com/api/push/scheduled/XY"
            },
                CancelByAliases = new List<string>()
                {
    "some_alias",
    "another_alias"
                },
                CancelByDeviceTokens = new List<string>()
                {
    "example_device_token",
    "other_example_device_token"
                }

            };
            List<JsonConverter> converters = new List<JsonConverter>();
            //converters.Add(new SchedulerConverter());
            string serializedToken = Newtonsoft.Json.JsonConvert.SerializeObject(response, Newtonsoft.Json.Formatting.None,
                new Newtonsoft.Json.JsonSerializerSettings()
                {
                    NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore,
                    Converters = converters
                });
            Console.WriteLine("Serialized : " + serializedToken);

            Helper.AreJsonEqual(expected, serializedToken);

      
        }
    }
}
