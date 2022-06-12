using System;
using System.ComponentModel.DataAnnotations;

namespace Doctor.Scheduler.Api.Repositories.Models
{
    public class NotificationType
    {
        [Key]
        public int NotificationTypeId { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }
    }
}
