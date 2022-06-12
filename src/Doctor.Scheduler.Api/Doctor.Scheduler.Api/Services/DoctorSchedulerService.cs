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
        IEnumerable<EventModels> GetEventById(int eventId);
    }

    public class DoctorSchedulerService : IDoctorSchedulerService
    {
        private readonly IDoctorSchedulerRespository _doctorSchedulerRespository;
        private readonly IAttendeesRepository _attendeesRepository;

        public DoctorSchedulerService(IDoctorSchedulerRespository doctorSchedulerRespository,
            IAttendeesRepository attendeesRepository)
        {
            _doctorSchedulerRespository = doctorSchedulerRespository;
            _attendeesRepository = attendeesRepository;
        }

        public bool CreateEvent(EventModelRequest eventModelRequest)
        {
            var attendee = _attendeesRepository.GetAttendeeById(eventModelRequest.Name);

            if (attendee == null)
                return false;

            var events = new Events()
            {
                AttendeesId = attendee.AttendeesId,
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
            var eventModels = new List<EventModels>();

            var result = _doctorSchedulerRespository.GetAllEvents().ToList();

            result.ForEach(item =>
            {
                var attendee = _attendeesRepository.GetAttendeeById(item.AttendeesId);

                var eventModel = new EventModels()
                {
                    EventId = item.EventId,
                    DateCreated = item.DateCreated,
                    Description = item.Description,
                    Title = item.Title,
                    StartTime = item.StartTime,
                    EndTime = item.EndTime,
                    AttendeeModel = new AttendeeModel()
                    {
                        Address = attendee.Address,
                        Email = attendee.Email,
                        IdNumber = attendee.IdNumber,
                        Name = attendee.Name,
                        AttendeesId = attendee.AttendeesId
                    }
                };

                eventModels.Add(eventModel);
            });

            return eventModels;
        }

        public IEnumerable<EventModels> GetEventById(int eventId)
        {
            var results = GetAllEvents();

            return results.Where(evt => evt.EventId == eventId);
        }
    }
}
