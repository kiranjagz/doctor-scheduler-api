using Doctor.Scheduler.Api.Repositories.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doctor.Scheduler.Api.Repositories
{
    public interface IDoctorSchedulerRespository
    {
        bool CreateEvent(Events AttendeeEvent);
        Events UpdateEvent(Events AttendeeEvent);
        bool DeleteEvent(int eventId);
        List<Events> GetAllEvents();
        List<Events> GetEventById(Events AttendeeEventId);
    }

    public class DoctorSchedulerRepository : IDoctorSchedulerRespository
    {
        private readonly DoctorSchedulerDbContext _doctorSchedulerDbContext;

        public DoctorSchedulerRepository()
        {
            _doctorSchedulerDbContext = new DoctorSchedulerDbContext();
        }

        public bool CreateEvent(Events AttendeeEvent)
        {
             _doctorSchedulerDbContext.Events.Add(AttendeeEvent);

            var result = _doctorSchedulerDbContext.SaveChanges();

            if (result > double.Epsilon)
                return true;

            return false;
        }

        public bool DeleteEvent(int eventId)
        {
            var result =  _doctorSchedulerDbContext.Find<Events>(eventId);

            var isDeleted = _doctorSchedulerDbContext.Events.Remove(result);
            _doctorSchedulerDbContext.SaveChanges();

            return isDeleted != null ? true : false;
        }

        public List<Events> GetAllEvents()
        {
            return _doctorSchedulerDbContext.Events.ToList();
        }

        public List<Events> GetEventById(Events AttendeeEventId)
        {
            return (List<Events>)_doctorSchedulerDbContext
                .Events
                .ToList()
                .Where(x => x.EventId == AttendeeEventId.EventId);
        }

        public Events UpdateEvent(Events AttendeeEvent)
        {
            throw new System.NotImplementedException();
        }
    }
}
