using System;

namespace Doctor.Scheduler.Api.Services
{
    public class NotificationSMSService : INotificationService
    {
        public bool SendNotification(string message)
        {
            Console.WriteLine($"Send message via sms: {message}");

            return true;
        }
    }
}
