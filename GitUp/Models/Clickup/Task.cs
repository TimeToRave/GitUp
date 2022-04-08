using System;
using System.Collections.Generic;
using System.Linq;
using GitUp.Interfaces;
using Newtonsoft.Json;

namespace GitUp.Models.Clickup
{
     public class Task : IClickupApiIntegrable
    {
        [JsonProperty("id")]
        public string Id;

        // [JsonProperty("custom_id")]
        // public object CustomId;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("text_content")]
        public string TextContent;
        
        [JsonProperty("description")]
        public string Description;
        
        [JsonProperty("status")]
        public Status Status;
        
        [JsonProperty("orderindex")]
        public string Orderindex;
        
        [JsonProperty("date_created")]
        public string DateCreated;
        
        [JsonProperty("date_updated")]
        public string DateUpdated;
        
        [JsonProperty("date_closed")]
        public object DateClosed;
        
        [JsonProperty("archived")]
        public bool Archived;
        
        [JsonProperty("creator")]
        public Creator Creator;
        
        [JsonProperty("assignees")]
        public List<Assignee> Assignees;
        
        [JsonProperty("watchers")]
        public List<Watcher> Watchers;
        
        [JsonProperty("checklists")]
        public List<Checklist> Checklists;
        
        [JsonProperty("tags")]
        public List<object> Tags;
        
        [JsonProperty("parent")]
        public object Parent;
        
        [JsonProperty("priority")]
        public object Priority;
        
        [JsonProperty("due_date")]
        public string DueDate;
        
        [JsonProperty("start_date")]
        public string StartDate;
        
        [JsonProperty("points")]
        public object Points;
        
        [JsonProperty("time_estimate")]
        public object TimeEstimate;
        
        [JsonProperty("time_spent")]
        public int TimeSpent;
        
        [JsonProperty("custom_fields")]
        public List<CustomField> CustomFields;
        
        [JsonProperty("dependencies")]
        public List<object> Dependencies;
        
        [JsonProperty("linked_tasks")]
        public List<object> LinkedTasks;
        
        [JsonProperty("team_id")]
        public string TeamId;
        
        [JsonProperty("url")]
        public string Url;
        
        [JsonProperty("permission_level")]
        public string PermissionLevel;
        
        [JsonProperty("list")]
        public List List;
        
        [JsonProperty("project")]
        public Project Project;
        
        [JsonProperty("folder")]
        public Folder Folder;
        
        [JsonProperty("space")]
        public Space Space;
        
        [JsonProperty("attachments")]
        public List<object> Attachments;

        public static Task Deserialize(string json)
        {
            Task task = JsonConvert.DeserializeObject<Task>(json);
            return task;
        }

        public Checklist GetChecklist(string checkListName)
        {
            return Checklists.FirstOrDefault(cl => string.Equals(cl.Name, checkListName, StringComparison.CurrentCultureIgnoreCase));
        }
        
        public bool GetIsCheckListExists(string checkListName)
        {
            Checklist? checkList = GetChecklist(checkListName);
            return checkList != null;
        }
    }
     
      public class Status
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("status")]
        public string StatusName;

        [JsonProperty("color")]
        public string Color;

        [JsonProperty("orderindex")]
        public int Orderindex;

        [JsonProperty("type")]
        public string Type;
    }

    public class Creator
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("username")]
        public string Username;

        [JsonProperty("color")]
        public string Color;

        [JsonProperty("email")]
        public string Email;

        [JsonProperty("profilePicture")]
        public string ProfilePicture;
    }

    public class Assignee
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("username")]
        public string Username;

        [JsonProperty("color")]
        public string Color;

        [JsonProperty("initials")]
        public string Initials;

        [JsonProperty("email")]
        public string Email;

        [JsonProperty("profilePicture")]
        public string ProfilePicture;
    }

    public class Watcher
    {
        [JsonProperty("id")]
        public int Id;

        [JsonProperty("username")]
        public string Username;

        [JsonProperty("color")]
        public string Color;

        [JsonProperty("initials")]
        public string Initials;

        [JsonProperty("email")]
        public string Email;

        [JsonProperty("profilePicture")]
        public string ProfilePicture;
    }

    public class Option
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("color")]
        public string Color;

        [JsonProperty("orderindex")]
        public int Orderindex;
    }

    public class TypeConfig
    {
        [JsonProperty("default")]
        public int Default;

        [JsonProperty("placeholder")]
        public object Placeholder;

        [JsonProperty("new_drop_down")]
        public bool NewDropDown;

        // [JsonProperty("options")]
        // public List<Option> Options;
    }

    public class CustomField
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("type")]
        public string Type;

        [JsonProperty("type_config")]
        public TypeConfig TypeConfig;

        [JsonProperty("date_created")]
        public string DateCreated;

        [JsonProperty("hide_from_guests")]
        public bool HideFromGuests;

        [JsonProperty("required")]
        public bool Required;
    }

    public class List
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("access")]
        public bool Access;
    }

    public class Project
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("hidden")]
        public bool Hidden;

        [JsonProperty("access")]
        public bool Access;
    }

    public class Folder
    {
        [JsonProperty("id")]
        public string Id;

        [JsonProperty("name")]
        public string Name;

        [JsonProperty("hidden")]
        public bool Hidden;

        [JsonProperty("access")]
        public bool Access;
    }

    public class Space
    {
        [JsonProperty("id")]
        public string Id;
    }
    
}