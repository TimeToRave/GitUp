using GitUp.Interfaces;
using Newtonsoft.Json;
using System;

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

        // [JsonProperty("items")]
        // public List<object> Items;

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
}