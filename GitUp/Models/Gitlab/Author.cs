using Newtonsoft.Json;

namespace GitUp.Models.Gitlab
{
    public class Author
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("email")]
        public string Email;
    }
}