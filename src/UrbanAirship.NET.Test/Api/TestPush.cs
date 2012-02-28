using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrbanAirship.NET.Schema;

namespace UrbanAirship.NET.Test.Api
{
    [TestClass]
    public class TestPush
    {
        [TestInitialize]
        public void Init()
        {
            System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
        }

        [TestMethod]
        public void TestAndroidPushMessage()
        {
            Assert.IsTrue(TestConfig.UseLiveTests);
            var pushApi = new NET.Api.PushNotification(TestConfig.ApplicationKey, TestConfig.ApplicationMasterSecret);
            pushApi.SendNotification(new AndroidBatchPushNotificationRequest()
             {
                  new AndroidPushNotificationRequest()
                  {
                       APIDS = new List<string> { "68b62108-1638-4cb1-950b-f4552fe974e7"},
                       APS = new AndroidAPSBody()
                      {
                           Alert="hello world "+ DateTime.Now
                      }
                  }
             });
        }
    }
}
