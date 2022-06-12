using System.ComponentModel.DataAnnotations;

namespace Doctor.Scheduler.Api.Repositories.Models
{
    public class Attendees
    {
        [Key]
        public int AttendeesId { get; set; }
        public string IdNumber { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
