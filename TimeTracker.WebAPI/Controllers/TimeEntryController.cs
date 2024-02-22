using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTracker.Shared.DTOs.TimeEntryDTO;
using TimeTracker.Shared.Entities;
using TimeTracker.WebAPI.Repositories;
using TimeTracker.WebAPI.Services;

namespace TimeTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeEntryController : ControllerBase
    {

        private readonly ITimeEntryService timeEntryService;

        public TimeEntryController(ITimeEntryService timeEntryService)
        {

            this.timeEntryService = timeEntryService;
        }


        [HttpGet]
        public ActionResult<List<TimeEntryResponseDto>> GetAllTimeEntries()
        {
            return Ok(timeEntryService.GetAllTimeEntries());

        }
        [HttpGet("{id}")]
        public ActionResult<TimeEntryResponseDto> GetTimeEntryById(int id)
        {
            var result = timeEntryService.GetTimeEntryById(id);
            if (result is null)
            {
                return NotFound("Time entry with the given id was not found..");
            }
            return Ok(result);
            
        }

        [HttpPost]
        public ActionResult<List<TimeEntryResponseDto>> CreateTimeEntry(TimeEntryCreateRequest timeEntry)
        {
            var newTimeEntry = timeEntryService.CreateTimeEntry(timeEntry);
            return Ok(newTimeEntry);

        }
        [HttpPut("{id}")]
        public ActionResult<List<TimeEntryResponseDto>> UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry)
        {
            var result = timeEntryService.UpdateTimeEntry(id, timeEntry);
            if(result is null)
            {
                return NotFound("Time entry with the given id was not found..");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<TimeEntryResponseDto>> DeleteTimeEntry(int id)
        {
            var result = timeEntryService.DeleteTimeEntry(id);
            if (result is null)
            {
                return NotFound("Time entry with the given id was not found..");
            }
            return Ok(result);
        }
    }
}
