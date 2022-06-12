namespace Doctor.Scheduler.Api.Services
{
    interface INotificationService
    {
        bool SendNotification(string message);
    }
}
