using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace HouseholdManager.Models
{
    /// <summary>
    /// Icons pulled from OpenEmoji API
    /// </summary>
    public class Icon
    {
        public string Slug { get; set; }
        public string Character { get; set; }
        public string UnicodeName { get; set; }
        public string CodePoint { get; set; }
        public string Group { get; set; }
        public string SubGroup { get; set; }
    }
}
