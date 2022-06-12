using Doctor.Scheduler.Api.Services.Models;
using System;

namespace Doctor.Scheduler.Api.Services
{
    public class NotificationEmailService : INotificationService
    {
        public NotificationEmailService()
        {

        }

        public NotificationEventModel SendNotification(string message)
        {
            // todo pass repo save and stragegy to send message
            var smsMessage = $"Email message with: {message}";

            return new NotificationEventModel
            {
                Message = smsMessage,
                IsSent = true
            };
        }
    }
}
