using Newtonsoft.Json;

namespace GitUp.Models.Clickup
{
    public class CheckListResponse
    {
        [JsonProperty("checklist")]
        public Checklist Checklist;

        public static CheckListResponse Deserialize(string json)
        {
            CheckListResponse checklistResponse = JsonConvert.DeserializeObject<CheckListResponse>(json);
            return checklistResponse;
        }
    }
}
