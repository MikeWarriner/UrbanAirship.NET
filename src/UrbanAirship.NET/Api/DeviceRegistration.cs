using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanAirship.NET.Schema;

namespace UrbanAirship.NET.Api
{
    public class DeviceRegistration : ApiBase
    {
        public DeviceRegistration(string appKey, string masterKey)
            : base("https://go.urbanairship.com", appKey, masterKey)
        { }


        public void RegisterDevice(string deviceToken)
        {
            base.Invoke<NullRequest, NullResponse>("/api/device_tokens/" + deviceToken + "/", RestSharp.Method.PUT, null);
        }
        public void RegisterDeviceWithInfo(string deviceToken, IOSDeviceTokenRegistrationInfo request)
        {
            base.Invoke<IOSDeviceTokenRegistrationInfo, NullResponse>("/api/device_tokens/" + deviceToken + "/", RestSharp.Method.PUT, request);
        }

        public IOSDeviceTokenRegistrationInfo QueryDeviceInfo(string deviceToken)
        {
            return base.Invoke<NullRequest, IOSDeviceTokenRegistrationInfo>("/api/device_tokens/" + deviceToken + "/", RestSharp.Method.GET, null);
        }
        public void DeleteDeviceInfo(string deviceToken)
        {
            base.Invoke<NullRequest, NullResponse>("/api/device_tokens/" + deviceToken + "/", RestSharp.Method.DELETE, null);
        }
    }
}
