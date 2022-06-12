using System;

namespace Doctor.Scheduler.Api.Services.Models
{
    public class EventModels
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int AttendeesId { get; set; }
    }
}
