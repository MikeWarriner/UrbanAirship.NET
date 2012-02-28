Very simple (and alpha quality) library for accessing UrbanAirship from your server app in .NET.

If you use this (or want to), please get in touch and I'll put some more effort into it.

Simple usage:

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
