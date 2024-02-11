using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Shared.Entities;

namespace TimeTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {
        private List<TimeEntry> timeEntries = new List<TimeEntry>
        {
            new TimeEntry 
            { 
                Id = 1,
                Project = "Time Tracker App",
                End = DateTime.Now.AddHours(1),
            }
        };

        [HttpGet]
        public ActionResult<List<TimeEntry>> GetAllTimeEntries()
        {
            return Ok(timeEntries);
        }

        [HttpPost]
        public ActionResult<List<TimeEntry>> CreateTimeEntry(TimeEntry timeEntry)
        {
            timeEntries.Add(timeEntry);
            return Ok(timeEntries);
        }
    }
}
