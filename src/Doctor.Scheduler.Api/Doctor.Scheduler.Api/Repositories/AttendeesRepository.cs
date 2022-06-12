using Doctor.Scheduler.Api.Repositories.Models;
using System.Linq;

namespace Doctor.Scheduler.Api.Repositories
{
    public interface IAttendeesRepository
    {
        Attendees GetAttendeeById(int attendeeId);
        Attendees GetAttendeeById(string attendeeName);
    }
    public class AttendeesRepository : IAttendeesRepository
    {
        private readonly DoctorSchedulerDbContext _doctorSchedulerDbContext;

        public AttendeesRepository()
        {
            _doctorSchedulerDbContext = new DoctorSchedulerDbContext();
        }

        public Attendees GetAttendeeById(int attendeeId)
        {
            return _doctorSchedulerDbContext.Find<Attendees>(attendeeId);
        }

        public Attendees GetAttendeeById(string attendeeName)
        {
            return _doctorSchedulerDbContext.Attendees.SingleOrDefault(x => x.Name.ToLower() == attendeeName.ToLower());
        }
    }
}
