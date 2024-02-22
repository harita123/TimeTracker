using TimeTracker.Shared.Entities;

namespace TimeTracker.WebAPI.Repositories
{
    public class TimeEntryRepository : ITimeEntryRepository
    {
        private static List<TimeEntry> timeEntries = new List<TimeEntry>
        {
            new TimeEntry
            {
                Id = 1,
                Project = "Time Tracker App",
                End = DateTime.Now.AddHours(1),
            }
        };
        public List<TimeEntry> CreateTimeEntryAsync(TimeEntry timeEntry)
        {
            timeEntries.Add(timeEntry);
            return timeEntries;
        }

        public List<TimeEntry>? DeleteTimeEntryAsync(int id)
        {
            var timeEntryToDelete = timeEntries.FirstOrDefault(t => t.Id == id);
            if(timeEntryToDelete == null)
            {
                return null;
            }
            timeEntries.Remove(timeEntryToDelete);
            return timeEntries;
        }

        public List<TimeEntry> GetAllTimeEntriesAsync()
        {
            
            return timeEntries;
        }

        public TimeEntry? GetTimeEntryById(int id)
        {
            return timeEntries.FirstOrDefault(t => t.Id == id);
        }

        public List<TimeEntry>? UpdateTimeEntryAsync(int id, TimeEntry timeEntry)
        {
            var timeEntryToUpdate = timeEntries.FindIndex(t => t.Id == id);
            if (timeEntryToUpdate == -1)
            {
                return null;
            }
            timeEntries[timeEntryToUpdate] = timeEntry;
            return timeEntries;
        }
    }
}
