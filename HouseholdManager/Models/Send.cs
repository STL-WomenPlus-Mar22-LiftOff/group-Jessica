using System.ComponentModel.DataAnnotations.Schema;

namespace HouseholdManager.Models
{
    public class Send
    {
        public int SendId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public MessageStatus Status { get; set; }
        public string? Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MessagePropertyId { get; set; }

        [ForeignKey("MessagePropertyId")]
        public MessageProperty? MessageProperty { get; set; }
    }

    public enum MessageStatus
    {
        Pending = 0,
        Confirmed = 1,
        Rejected = 2
    }
}
