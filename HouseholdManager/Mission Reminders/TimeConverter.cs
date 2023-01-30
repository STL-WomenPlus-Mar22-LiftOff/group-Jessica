namespace HouseholdManager.Mission_Reminders
{
    public interface ITimeConverter
    {
        DateTime ToLocalTime(DateTime time, string timezone);
    }

    public class TimeConverter : ITimeConverter
    {
        public DateTime ToLocalTime(DateTime time, string timezone)
        {
            return TimeZoneInfo.ConvertTimeToUtc(
                time,
                TimeZoneInfo.FindSystemTimeZoneById(timezone))
                .ToLocalTime();
        }
    }
}