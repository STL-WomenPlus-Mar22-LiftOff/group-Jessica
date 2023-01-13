using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json.Serialization;

namespace HouseholdManager.Models
{
    /// <summary>
    /// <para>Icons pulled from OpenEmoji API.</para>
    /// <para>Obtained through <see cref="HouseholdManager.Data.API.IconRequestor"/></para>
    /// <seealso href="https://emoji-api.com/#documentation">Open Emoji API Documentation</seealso>
    /// </summary>
    public class Icon
    {
        [JsonPropertyName("slug")]
        public string? Slug { get; set; }

        public string? Character { get; set; }

        //Unused properties are commented out for now.
        /*
        public string? UnicodeName { get; set; }
        
        public string? CodePoint { get; set; }
        
        public string? Group { get; set; }
        
        public string? SubGroup { get; set; }
        */
    }
}
