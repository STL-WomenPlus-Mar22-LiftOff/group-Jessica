using HouseholdManager.Models;
using System.Text.Json;

namespace HouseholdManager.Data.API
{
    /// <summary>
    /// <para>Class for interfacing with the Open Emoji API</para>
    /// <seealso href="https://emoji-api.com/#documentation">Open Emoji API Documentation</seealso>
    /// </summary>
    public class IconRequestor
    {
        private const string OpenEmojiApiKey = "2f3055e94632aca65cac6bbe8c8488c414cc9a27";

        /// <summary>
        /// Gets a list of all available icons matching the search term from Open Emoji API
        /// </summary>
        /// <param name="searchTerm"></param>
        public async Task<List<Icon>> GetIconsFromApi(string searchTerm = "")
        {
            string path;
            if (string.IsNullOrEmpty(searchTerm))
            {
                path = $"https://emoji-api.com/emojis?access_key={OpenEmojiApiKey}";
            }
            else
            {
                path = $"https://emoji-api.com/emojis?search={searchTerm}&access_key={OpenEmojiApiKey}";
            }

            try
            {
                var iconList = await DeserializeIconData(path);
                return iconList;
            }
            catch (BadHttpRequestException e)
            {
                Console.Error.WriteLine(e.Message);
                return new List<Icon>();
            }
        }

        /// <summary>
        /// Helper method for GetIconsFromApi(), handles response.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>A list of icons, if successful</returns>
        /// <exception cref="BadHttpRequestException"></exception>
        private async Task<List<Icon>> DeserializeIconData(string path)
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(path))
                {
                    string rawData = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    return JsonSerializer.Deserialize<List<Icon>>(rawData, options)
                           ?? throw new BadHttpRequestException($"Unable to load icons - null or bad JSON data retrieved from OpenEmoji API.  Request path: {path}");
                }
            }
        }

        /// <summary>
        /// <para>Fetches corresponding Unicode slug from Open Emoji API when passed an icon</para>
        /// <para>This method is not particularly fast, as the API does not natively support this 
        /// type of search.  It has to get and then query the entire list of thousands of emojis.</para>
        /// <para>Call this sparingly.</para>
        /// </summary>
        /// <param name="iconLiteral"></param>
        /// <returns>Unicode slug for provided emoji, if found, otherwise an empty string</returns>
        public async Task<string> GetMouseoverTextForIcon(string iconLiteral)
        {
            if (string.IsNullOrEmpty(iconLiteral))
            {
                return "";
            }
            List<Icon> allIcons = await GetIconsFromApi();
            var query = from icon in allIcons
                        where icon.Character == iconLiteral
                        select icon.Slug;
            return query.FirstOrDefault() ?? "";

        }
    }
}
