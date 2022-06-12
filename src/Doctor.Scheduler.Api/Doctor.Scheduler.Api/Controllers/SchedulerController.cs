using Doctor.Scheduler.Api.Repositories;
using Doctor.Scheduler.Api.Services;
using Doctor.Scheduler.Api.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Doctor.Scheduler.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulerController : ControllerBase
    {
        private readonly IDoctorSchedulerService _SchedulerService;

        public SchedulerController(IDoctorSchedulerService schedulerService)
        {
            _SchedulerService = schedulerService;
        }

        // GET: api/<SchedulerController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var results = _SchedulerService.GetAllEvents().ToList();

                if (!results.Any()) return BadRequest("Did not return any elements for events");

                return Ok(results);
            }
            catch (Exception e)
            {
                return BadRequest($"An error has occurred with getting all events: {e.Message}");
            }
        }

        // GET api/<SchedulerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var results = _SchedulerService.GetEventById(id);

                if (!results.Any()) return BadRequest($"Did not return any elements for events with id: {id}");

                return Ok(results);
            }
            catch (Exception e)
            {
                return BadRequest($"An error has occurred with getting all an event with id: {id}:: error :: {e.Message}");
            }
        }

        // POST api/<SchedulerController>
        [HttpPost]
        public IActionResult Post([FromBody] EventModelRequest eventModelRequest)
        {
            try
            {
                var hasInserted = _SchedulerService.CreateEvent(eventModelRequest);

                return Ok(new
                {
                    message = "A request has been sent to try to insert a row",
                    hasInserted = hasInserted
                });
            }
            catch (Exception e)
            {
                return BadRequest($"An error has occurred with creating an event: {e.Message}");
            }
        }

        // DELETE api/<SchedulerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var hasDeleted = _SchedulerService.DeleteEvent(id);

                return Ok(new
                {
                    message = "A request has been sent to try to delete a row",
                    hasDeleted = hasDeleted
                });
            }
            catch (Exception e)
            {
                return BadRequest($"An error has occurred with deleting an event: {e.Message}");
            }
        }

        // PUT api/<SchedulerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
