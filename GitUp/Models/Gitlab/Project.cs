using Newtonsoft.Json;

namespace GitUp.Models.Gitlab
{
    public class Project
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("description")]
        public string Description;

        [JsonProperty("web_url")]
        public string WebUrl;

        [JsonProperty("avatar_url")]
        public object AvatarUrl;

        [JsonProperty("git_ssh_url")]
        public string GitSshUrl;

        [JsonProperty("git_http_url")]
        public string GitHttpUrl;

        [JsonProperty("namespace")]
        public string Namespace;

        [JsonProperty("visibility_level")]
        public int VisibilityLevel;

        [JsonProperty("path_with_namespace")]
        public string PathWithNamespace;

        [JsonProperty("default_branch")]
        public string DefaultBranch;

        [JsonProperty("ci_config_path")]
        public object CiConfigPath;

        [JsonProperty("homepage")]
        public string Homepage;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("ssh_url")]
        public string SshUrl;

        [JsonProperty("http_url")]
        public string HttpUrl;
    }
}