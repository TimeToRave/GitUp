using Newtonsoft.Json;

namespace GitUp.Models.Gitlab
{
    public class Repository
    {
        [JsonProperty("name")]
        public string Name;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("homepage")]
        public string Homepage;

        [JsonProperty("git_http_url")]
        public string GitHttpUrl;

        [JsonProperty("git_ssh_url")]
        public string GitSshUrl;

        [JsonProperty("visibility_level")]
        public int VisibilityLevel;
    }
}