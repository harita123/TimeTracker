using TimeTracker.Shared.DTOs.TimeEntryDTO;

namespace TimeTracker.WebAPI.Services
{
    public interface ITimeEntryService
    {
        TimeEntryResponseDto? GetTimeEntryById(int id);
        List<TimeEntryResponseDto> GetAllTimeEntries();
        List<TimeEntryResponseDto> CreateTimeEntry(TimeEntryCreateRequest timeEntry);
        List<TimeEntryResponseDto>? UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry);
        List<TimeEntryResponseDto>? DeleteTimeEntry(int id);
    }
}
