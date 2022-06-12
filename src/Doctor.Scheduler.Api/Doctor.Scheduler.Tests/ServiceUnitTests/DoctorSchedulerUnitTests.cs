using Doctor.Scheduler.Api.Repositories;
using Doctor.Scheduler.Api.Repositories.Models;
using Doctor.Scheduler.Api.Services;
using Doctor.Scheduler.Api.Services.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.Scheduler.Tests.ServiceUnitTests
{
    [TestFixture]
    public class DoctorSchedulerUnitTests
    {
        private Mock<IDoctorSchedulerRespository> _schedulerRepoitory;
        private Mock<IAttendeesRepository> _attendeesRepository;
        private IDoctorSchedulerService _schedulerService;
        private EventModelRequest _eventRequest;

        [SetUp]
        public void Setup()
        {
            _schedulerRepoitory = new Mock<IDoctorSchedulerRespository>();
            _attendeesRepository = new Mock<IAttendeesRepository>();
            _schedulerService = new DoctorSchedulerService(_schedulerRepoitory.Object, _attendeesRepository.Object);

            _eventRequest = new EventModelRequest()
            {
                Name = "Bob",
                DateCreated = DateTime.Now,
                Description = "test",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(1),
                Title = "Off Sick"
            };
        }

        [TestCase("Bob", true)]
        public void Check_that_can_insert_for_an_event_should_return_true(string attendeeName, bool expectedResult)
        {
            var eventModel = Mock.Of<Events>(x => x.EventId == 1
            && x.Title == "test"
            && x.AttendeesId == 2
            && x.DateCreated == DateTime.Now
            && x.Description == "test");

            _schedulerRepoitory.Setup(p => p.CreateEvent(eventModel)).Returns(true);

            _attendeesRepository.Setup(p => p.GetAttendeeByName(attendeeName))
                .Returns(new Attendees
                {
                    AttendeesId = 1,
                    Address = "1 address",
                    IdNumber = "000000000000",
                    Email = "bob@email.com",
                    Name = attendeeName
                });

            var result = _schedulerService.CreateEvent(_eventRequest);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(expectedResult);
            });
        }

        [TestCase("Bob", false)]
        public void Check_that_can_insert_for_an_event_should_return_false(string attendeeName, bool expectedResult)
        {
            _schedulerRepoitory.Setup(p => p.CreateEvent(null)).Returns(false);

            _attendeesRepository.Setup(p => p.GetAttendeeByName(attendeeName))
                .Returns(new Attendees
                {
                    AttendeesId = 1,
                    Address = "1 address",
                    IdNumber = "000000000000",
                    Email = "bob@email.com",
                    Name = attendeeName
                });

            var result = _schedulerService.CreateEvent(_eventRequest);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(expectedResult);
            });
        }
    }
}
