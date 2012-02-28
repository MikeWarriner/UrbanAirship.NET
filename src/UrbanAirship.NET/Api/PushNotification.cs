using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrbanAirship.NET.Schema;

namespace UrbanAirship.NET.Api
{
    public class PushNotification : ApiBase
    {
        public PushNotification(string appKey, string masterKey)
            : base("https://go.urbanairship.com", appKey, masterKey)
        { }

        public void SendNotification(IOSPushNotificationRequest pushRequest)
        {
            base.Invoke<IOSPushNotificationRequest, NullResponse>("/api/push/", RestSharp.Method.POST, pushRequest);
        }
        public void SendNotification(IOSBatchPushNotificationRequest pushRequest)
        {
            base.Invoke<IOSBatchPushNotificationRequest, NullResponse>("/api/push/batch/", RestSharp.Method.POST, pushRequest);
        }
        public void SendNotification(AndroidPushNotificationRequest pushRequest)
        {
            base.Invoke<AndroidPushNotificationRequest, NullResponse>("/api/push/", RestSharp.Method.POST, pushRequest);
        }
        public void SendNotification(AndroidBatchPushNotificationRequest pushRequest)
        {
            base.Invoke<AndroidBatchPushNotificationRequest, NullResponse>("/api/push/batch/", RestSharp.Method.POST, pushRequest);
        }

        public void SendBroadcast(IOSBroadcastRequest broadcastRequest)
        {
            base.Invoke<IOSBroadcastRequest, NullResponse>("/api/push/broadcast/", RestSharp.Method.POST, broadcastRequest);
        }
        public void SendBroadcast(AndroidBroadcastRequest broadcastRequest)
        {
            base.Invoke<AndroidBroadcastRequest, NullResponse>("/api/push/broadcast/", RestSharp.Method.POST, broadcastRequest);
        }

        public IOSPushNotificationResponse SendScheduledNotification(IOSScheduledPushNotificationRequest request)
        {
            return base.Invoke<IOSScheduledPushNotificationRequest, IOSPushNotificationResponse>("/api/push/", RestSharp.Method.POST, request);
        }
        public void CancelScheduledNotification(IOSCancelPushNotificationRequest request)
        {
            base.Invoke<IOSCancelPushNotificationRequest, NullResponse>("/api/push/scheduled/", RestSharp.Method.POST, request);
        }
    }
}
