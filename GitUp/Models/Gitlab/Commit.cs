using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GitUp.Models.Gitlab
{
    public class Commit
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("message")]
        public string Message;

        [JsonProperty("title")]
        public string Title;

        [JsonProperty("timestamp")]
        public DateTime Timestamp;

        [JsonProperty("url")]
        public string Url;

        [JsonProperty("author")]
        public Author Author;

        [JsonProperty("added")]
        public List<object> Added;

        [JsonProperty("modified")]
        public List<string> Modified;

        [JsonProperty("removed")]
        public List<object> Removed;
    }
}