using System.Globalization;

namespace HouseholdManager.Mission_Reminders
{
    public class DateTimeExtension
    {
        public static string ToCustomDateString(this DateTime dateTime)
        {
            return dateTime.ToString("MM/dd/yyyy hh:mm tt", new CultureInfo("en-US"));
        }
    }
}
