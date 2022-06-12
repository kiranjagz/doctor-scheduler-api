using Doctor.Scheduler.Api.Repositories;
using Doctor.Scheduler.Api.Services;
using Doctor.Scheduler.Api.Services.Models;
using Microsoft.AspNetCore.Mvc;

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
            var results = _SchedulerService.GetAllEvents();

            return Ok(results);
        }

        // GET api/<SchedulerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SchedulerController>
        [HttpPost]
        public IActionResult Post([FromBody] EventModelRequest eventModelRequest)
        {
            var results = _SchedulerService.CreateEvent(eventModelRequest);

            return Ok(results);
        }

        // PUT api/<SchedulerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SchedulerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var results = _SchedulerService.DeleteEvent(id);

            return Ok(results);
        }
    }
}
