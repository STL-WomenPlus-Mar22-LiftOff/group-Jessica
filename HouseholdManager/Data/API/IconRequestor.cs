using HouseholdManager.Models;
using System.Text.Json;

namespace HouseholdManager.Data.API
{
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
                Console.WriteLine(e.Message);
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
    }
}
