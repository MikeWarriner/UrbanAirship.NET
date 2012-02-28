using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UrbanAirship.NET.Test.Api
{
    [TestClass]
    public class TestStatistics
    {
        [TestInitialize]
        public void Init()
        {
            System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
        }

#if false
        [TestMethod]
        public void TestQueryDevices()
        {
            Assert.IsTrue(TestConfig.UseLiveTests);
            UrbanAirship.NET.Api.Statistics stats = new NET.Api.Statistics(TestConfig.ApplicationKey, TestConfig.ApplicationMasterSecret);
            var response = stats.QueryAndroidDeviceTokenCount();
            Assert.IsNotNull(response);
            Console.WriteLine("response : " + response.ActiveDeviceCount + "/" + response.DeviceTokenCount);
            Assert.AreNotEqual(0, response.ActiveDeviceCount);
        }
#endif
        [TestMethod]
        public void TestQueryAndroidDeviceList()
        {
            Assert.IsTrue(TestConfig.UseLiveTests);
            UrbanAirship.NET.Api.Statistics stats = new NET.Api.Statistics(TestConfig.ApplicationKey, TestConfig.ApplicationMasterSecret);
            var response = stats.QueryAndroidDeviceTokenReport(10,null);
            Assert.IsNotNull(response);
            Console.WriteLine("response : " + response.APIDS.Count);
            Assert.AreNotEqual(0, response.APIDS.Count);
            Assert.IsTrue(response.APIDS[0].IsActive);

        }
#if false
        [TestMethod]
        public void TestQueryDeviceList()
        {
            Assert.IsTrue(TestConfig.UseLiveTests);
            UrbanAirship.NET.Api.Statistics stats = new NET.Api.Statistics(ApplicationKey, ApplicationMasterSecret);
            var response = stats.QueryDeviceTokenReport(0, 10);
            Assert.IsNotNull(response);
            Console.WriteLine("response : " + response.ActiveDeviceCount + "/" + response.DeviceTokenCount);
            
        }
#endif
    }
}
