using Doctor.Scheduler.Api.Services.Models;
using System;

namespace Doctor.Scheduler.Api.Services
{
    public class NotificationSMSService : INotificationService
    {
        public NotificationSMSService()
        {

        }

        public NotificationEventModel SendNotification(string message)
        {
            // todo pass repo save and stragegy to send message
            var smsMessage = $"SMS message with: {message}";

            return new NotificationEventModel
            {
                Message = smsMessage,
                IsSent = true
            };
        }
    }
}
