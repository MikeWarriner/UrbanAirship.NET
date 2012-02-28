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
    public class AndroidPushNotificationTests
    {
        [TestMethod]
        public void TestSchemaAndroidPushNotification()
        {
            string expected = "" +
            "{" +
    "\"apids\": [" +
    "    \"some device token\"," +
    "    \"another device token\"" +
    "]," +
    "\"aliases\": [" +
    "    \"user1\"," +
    "    \"user2\"" +
    "]," +
    "\"tags\": [" +
    "    \"tag1\"," +
    "    \"tag2\"" +
    "]," +
    "\"android\": {" +
    "     \"alert\": \"hello world\"" +
    "}}";

            var push = new AndroidPushNotificationRequest()
            {
                Aliases = new List<string>() { "user1", "user2" },
                APS = new AndroidAPSBody()
                {
                    Alert = "hello world"
                },
                Tags = new List<string>() { "tag1", "tag2" },
                APIDS = new List<string>() { "some device token", "another device token" },
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
        public void TestSchemaAndroidBroadcastMessage()
        {
            string expected = "" +
                "{" +
                    "\"android\": {" +
                        "\"alert\": \"Hello from Urban Airship!\"" +
                    "}" +
                "}";
            var push = new AndroidBroadcastRequest()
            {
                APS = new AndroidAPSBody()
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
        public void TestSchemaAndroidAutoUpdate()
        {
            string expected = "" +
            "{" +
     "\"apids\": [\"apidone\"]," +
     "\"android\": {" +
         "\"alert\": \"My badge is now 4!\"" +
    "}";

            var push = new AndroidPushNotificationRequest()
            {
                 APIDS = new List<string> { "apidone"},
                APS = new AndroidAPSBody()
                {
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
    }
}