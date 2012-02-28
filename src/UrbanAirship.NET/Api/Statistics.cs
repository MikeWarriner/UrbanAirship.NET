using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanAirship.NET.Schema;

namespace UrbanAirship.NET.Api
{
    public class Statistics : ApiBase
    {
        public Statistics(string appKey, string masterKey)
            : base("https://go.urbanairship.com", appKey, masterKey)
        { }

        public IOSDeviceTokenCountResponse QueryIOSDeviceTokenCount()
        {
            return base.Invoke<NullRequest, IOSDeviceTokenCountResponse>("/api/device_tokens/count/", RestSharp.Method.GET, null);
        }
        public IOSDeviceTokenReportResponse QueryIOSDeviceTokenReport(int pageNumber, int requestLimit)
        {
            return base.Invoke<NullRequest, IOSDeviceTokenReportResponse>("/api/device_tokens/?page=" + pageNumber + "&limit=" + requestLimit, RestSharp.Method.GET, null);

        }
        /*public AndroidDeviceTokenCountResponse QueryAndroidDeviceTokenCount()
        {
            return base.Invoke<NullRequest, AndroidDeviceTokenCountResponse>("/api/apids/count/", RestSharp.Method.GET, null);
        }
         * */
        public AndroidDeviceTokenReportResponse QueryAndroidDeviceTokenReport(int requestLimit, string nextRequestUrl)
        {
            if (!String.IsNullOrWhiteSpace(nextRequestUrl))
            {
                nextRequestUrl = nextRequestUrl.Substring(base.Url.Length);
                return base.Invoke<NullRequest, AndroidDeviceTokenReportResponse>(nextRequestUrl, RestSharp.Method.GET, null);
            }
            else
            {
                return base.Invoke<NullRequest, AndroidDeviceTokenReportResponse>("/api/apids/?limit=" + requestLimit, RestSharp.Method.GET, null);
            }
        }
    }
}