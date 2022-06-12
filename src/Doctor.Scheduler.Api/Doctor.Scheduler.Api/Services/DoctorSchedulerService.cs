using Doctor.Scheduler.Api.Repositories;
using Doctor.Scheduler.Api.Repositories.Models;
using Doctor.Scheduler.Api.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Doctor.Scheduler.Api.Services
{
    public interface IDoctorSchedulerService
    {
        bool CreateEvent(EventModelRequest eventModelRequest);

        bool DeleteEvent(int eventId);

        IEnumerable<EventModels> GetAllEvents();
    }

    public class DoctorSchedulerService : IDoctorSchedulerService
    {
        private readonly IDoctorSchedulerRespository _doctorSchedulerRespository;

        public DoctorSchedulerService(IDoctorSchedulerRespository doctorSchedulerRespository)
        {
            _doctorSchedulerRespository = doctorSchedulerRespository;
        }

        public bool CreateEvent(EventModelRequest eventModelRequest)
        {
            var events = new Events()
            {
                AttendeesId = eventModelRequest.AttendeesId,
                DateCreated = DateTime.Now,
                Description = eventModelRequest.Description,
                StartTime = eventModelRequest.StartTime,
                EndTime = eventModelRequest.EndTime,
                Title = eventModelRequest.Title
            };

            var result = _doctorSchedulerRespository.CreateEvent(events);

            return result;
        }

        public bool DeleteEvent(int eventId)
        {
            var result = _doctorSchedulerRespository.DeleteEvent(eventId);

            return result;
        }

        public IEnumerable<EventModels> GetAllEvents()
        {
            var result = _doctorSchedulerRespository.GetAllEvents()
                .Select(x => new EventModels
                {
                    AttendeesId = x.AttendeesId,
                    DateCreated = x.DateCreated,
                    Description = x.Description,
                    EndTime = x.EndTime,
                    StartTime = x.StartTime,
                    Title = x.Title
                }).ToList();

            return result;
        }
    }
}
