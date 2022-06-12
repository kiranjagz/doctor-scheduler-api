using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Doctor.Scheduler.Api.Repositories.Models
{
    public class Notifications
    {
        [Key]
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
        public int EventId { get; set; }
        [ForeignKey("NotificationTypeId")]
        public int NotificationTypeId { get; set; }
        public NotificationType NotificationTypes { get;set;}
    }
}
