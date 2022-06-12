using Doctor.Scheduler.Api.Services.Models;

namespace Doctor.Scheduler.Api.Services
{
    interface INotificationService
    {
        NotificationEventModel SendNotification(string message);
    }
}
