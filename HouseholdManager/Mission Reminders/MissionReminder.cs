using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HouseholdManager.Mission_Reminders
{
    public class MissionReminder
    {
        public class MissionReminder
        {
            public static int ReminderTime = 30;
            public int Id { get; set; }

            [Required]
            public string MemberName { get; set; }

            [Required, Phone, Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required]
            public DateTime Time { get; set; }

            [Required]
            public string Timezone { get; set; }

            [Display(Name = "Created at")]
            public DateTime CreatedAt { get; set; }
        }
    }
}
}
