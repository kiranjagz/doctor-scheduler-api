using System;

namespace Doctor.Scheduler.Api.Services
{
    public class NotificationEmailService : INotificationService
    {
        public NotificationEmailService()
        {

        }

        public bool SendNotification(string message)
        {
            Console.WriteLine($"Send message via email: {message}");

            return true;
        }
    }
}
