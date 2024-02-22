using Mapster;
using TimeTracker.Shared.DTOs.TimeEntryDTO;
using TimeTracker.Shared.Entities;
using TimeTracker.WebAPI.Repositories;

namespace TimeTracker.WebAPI.Services
{
    public class TimeEntryService : ITimeEntryService
    {
        private readonly ITimeEntryRepository timeEntryRepository;

        public TimeEntryService(ITimeEntryRepository timeEntryRepository)
        {
            this.timeEntryRepository = timeEntryRepository;
        }
        public List<TimeEntryResponseDto> CreateTimeEntry(TimeEntryCreateRequest timeEntry)
        {
            var newTimeEntry = timeEntry.Adapt<TimeEntry>();
            //var newTimeEntry = new TimeEntry
            //{
            //    Project = timeEntry.Project,
            //    Start = timeEntry.Start,
            //    End = timeEntry.End,
            //};
            var result = timeEntryRepository.CreateTimeEntryAsync(newTimeEntry);
            return result.Adapt<List<TimeEntryResponseDto>>();
            //return result.Select(t=> new TimeEntryResponseDto
            //{
            //    Id = t.Id,
            //    Project = t.Project,
            //    Start = t.Start,
            //    End = t.End,
            //}).ToList();
        }

        public List<TimeEntryResponseDto>? DeleteTimeEntry(int id)
        {
            var result = timeEntryRepository.DeleteTimeEntryAsync(id);
            if(result == null)
            {
                return null;
            }
            return result.Adapt<List<TimeEntryResponseDto>>();

        }

        public List<TimeEntryResponseDto> GetAllTimeEntries()
        {
            var result = timeEntryRepository.GetAllTimeEntriesAsync();
            return result.Adapt<List<TimeEntryResponseDto>>();
            //return result.Select(t => new TimeEntryResponseDto
            //{
            //    Id = t.Id,
            //    Project = t.Project,
            //    Start = t.Start,
            //    End = t.End,
            //}).ToList();
        }

        public TimeEntryResponseDto? GetTimeEntryById(int id)
        {
            var result = timeEntryRepository.GetTimeEntryById(id);
            if(result == null)
            {
                return null;
            }
            return result.Adapt<TimeEntryResponseDto>();
        }

        public List<TimeEntryResponseDto>? UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry)
        {
            var updatedTimeEntry = timeEntry.Adapt<TimeEntry>();
            var result = timeEntryRepository.UpdateTimeEntryAsync(id, updatedTimeEntry);
            if(result is null)
            {
                return null;
            }
            return result.Adapt<List<TimeEntryResponseDto>>();
        }
    }
}
