using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UrbanAirship.NET.Schema;

namespace UrbanAirship.NET.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TestSerialization
    {
        public TestSerialization()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestSchemaIOSDeviceToken()
        {
            //
            // TODO: Add constructor logic here
            //
           var token = new IOSDeviceTokenRegistrationInfo()
            {
                 Alias = "your_user_id",
                 Tags = new string[] { "tag1", "tag2"},
                 Badge = "2",
                 QuietTime = new QuietTime() { Start="22:00", End="8:00"},
                 TimeZone = "America/Los_Angeles"
            };
            string expected = 
                "{"+
                " \"alias\": \"your_user_id\", "+
                " \"tags\": [\"tag1\",\"tag2\"],"+
                " \"badge\": \"2\","+
                " \"quiettime\": {"+
                "     \"start\": \"22:00\","+
                "     \"end\": \"8:00\""+
                " },"+
                " \"tz\": \"America/Los_Angeles\""+
                "}";

            string serializedToken = Newtonsoft.Json.JsonConvert.SerializeObject(token);
            Console.WriteLine("Serialized : " + serializedToken);

            Helper.AreJsonEqual(expected, serializedToken);
        }
    }
}
