using TimeTracker.Shared.Entities;

namespace TimeTracker.WebAPI.Repositories
{
    public interface ITimeEntryRepository
    {
        TimeEntry? GetTimeEntryById(int id);
        List<TimeEntry> GetAllTimeEntriesAsync();
        List<TimeEntry> CreateTimeEntryAsync(TimeEntry timeEntry);
        List<TimeEntry>? UpdateTimeEntryAsync(int id, TimeEntry timeEntry);
        List<TimeEntry>? DeleteTimeEntryAsync(int id);
    }
}
