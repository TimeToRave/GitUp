using GitUp.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GitUp.Models.Clickup
{
    public class Checklist : IClickupApiIntegrable
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("task_id")]
        public string TaskId;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("date_created")]
        public string DateCreated;

        [JsonProperty("orderindex")]
        public int OrderIndex;

        [JsonProperty("creator")]
        public int Creator;

        [JsonProperty("resolved")]
        public int Resolved;

        [JsonProperty("unresolved")]
        public int Unresolved;

        [JsonProperty("items")]
        public List<CheckListItem> Items;

        public static Checklist Deserialize(string json)
        {
            Checklist checklist = JsonConvert.DeserializeObject<Checklist>(json);
            return checklist;
        }

		internal bool IsNullOrEmpty()
		{
            return Id is null;
		}
	}

    public class CheckListItem
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("assignee")]
        public Assignee Assignee;

        [JsonProperty("resolved")]
        public bool Resolved;

        [JsonProperty("date_created")]
        public string DateCreated;
    }

}