using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrbanAirship.NET.Schema;

namespace UrbanAirship.NET.Test.Api
{
    [TestClass]
    public class TestBroadcast
    {
        [TestInitialize]
        public void Init()
        {
            System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
        }


        [TestMethod]
        public void TestBroadcastToAndroid()
        {
            Assert.IsTrue(TestConfig.UseLiveTests);
            var pushApi = new NET.Api.PushNotification(TestConfig.ApplicationKey, TestConfig.ApplicationMasterSecret);
            pushApi.SendBroadcast(new AndroidBroadcastRequest() { APS = new AndroidAPSBody() { Alert = "hello : " + DateTime.Now } });
        }
    }
}