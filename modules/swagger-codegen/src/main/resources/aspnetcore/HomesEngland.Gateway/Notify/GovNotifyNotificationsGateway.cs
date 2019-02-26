using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using HomesEngland.Domain;
using HomesEngland.Gateway.Notifications;
using Notify.Client;
using Notify.Interfaces;

namespace HomesEngland.Gateway.Notify
{
    public class GovNotifyNotificationsGateway : IOneTimeLinkNotifier, IAssetRegisterUploadProcessedNotifier
    {
        public async Task<bool> SendOneTimeLinkAsync(IOneTimeLinkNotification notification,
            CancellationToken cancellationToken)
        {
            var client = NotificationClient();

            client.SendEmail(
                notification.Email,
                "8f02be8c-32db-4f18-97fe-1d60152e9b06",
                NotificationPersonalisation(notification)
            );

            return true;
        }

        public async Task<bool> SendUploadProcessedNotification(IUploadProcessedNotification notification,
            CancellationToken cancellationToken)
        {
            INotificationClient client = NotificationClient();

            if (notification.UploadSuccessfullyProcessed)
            {
                client.SendEmail(notification.Email, ProcessSuccessfulTemplateId());
            }
            else
            {
                client.SendEmail(notification.Email, ProcessUnsuccessfulTemplateId());
            }

            return true;
        }

        private static string ProcessSuccessfulTemplateId()
        {
            return "434e8133-b995-4363-a177-2bad0ea70773";
        }

        private static string ProcessUnsuccessfulTemplateId()
        {
            return "3e4d2aea-4305-461f-84f8-584361169c36";
        }

        private static INotificationClient NotificationClient()
        {
            string baseUrl = Environment.GetEnvironmentVariable("GOV_NOTIFY_URL");
            string apiKey = Environment.GetEnvironmentVariable("GOV_NOTIFY_API_KEY");

            INotificationClient client = new NotificationClient(baseUrl, apiKey);
            return client;
        }

        private static Dictionary<string, dynamic> NotificationPersonalisation(IOneTimeLinkNotification notification)
        {
            return new Dictionary<string, dynamic>
                {{"access_url", $"{notification.Url}?token={notification.Token}"}};
        }
    }
}
