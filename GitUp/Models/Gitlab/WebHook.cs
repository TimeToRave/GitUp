using System.Collections.Generic;
using Newtonsoft.Json;

namespace GitUp.Models.Gitlab
{
    public class WebHook
    {
        [JsonProperty("object_kind")]
        public string ObjectKind;

        [JsonProperty("event_name")]
        public string EventName;

        [JsonProperty("before")]
        public string Before;

        [JsonProperty("after")]
        public string After;

        [JsonProperty("ref")]
        public string Ref;

        [JsonProperty("checkout_sha")]
        public string CheckoutSha;

        [JsonProperty("message")]
        public object Message;

        [JsonProperty("user_id")]
        public int UserId;

        [JsonProperty("user_name")]
        public string UserName;

        [JsonProperty("user_username")]
        public string UserUsername;

        [JsonProperty("user_email")]
        public string UserEmail;

        [JsonProperty("user_avatar")]
        public string UserAvatar;

        [JsonProperty("project_id")]
        public int ProjectId;

        [JsonProperty("project")]
        public Project Project;

        [JsonProperty("commits")]
        public List<Commit> Commits;

        [JsonProperty("total_commits_count")]
        public int TotalCommitsCount;

        [JsonProperty("push_options")]
        public PushOptions PushOptions;

        [JsonProperty("repository")]
        public Repository Repository;
    }
}