using System;
using System.Text.RegularExpressions;
using GitUp.Interfaces;
using GitUp.Models.Clickup;
using GitUp.Models.Gitlab;
using Microsoft.AspNetCore.Mvc;

namespace GitUp.Controllers
{
    [ApiController]
	[Route("api/v1/[controller]/push")]
	public class GitlabController : ControllerBase
	{
		// private readonly ILogger<GitlabController> _logger;
		//
		// public GitlabController(ILogger<GitlabController> logger)
		// {
		// 	_logger = logger;
		// }

		[HttpPost]
        [AcceptVerbs("POST")]
        public string Post([FromBody] WebHook webHook)
		{
			IWebHookHandler handler = new ClickUpWebHookHandler();
			handler.HandlePushEvent(webHook);
			
			return String.Empty;
		}
	}

	public class ClickUpWebHookHandler : IWebHookHandler
	{
		public void HandlePushEvent(WebHook webHook)
		{
			foreach (var commit in webHook.Commits)
			{
				string taskIdWithBrackets = GetTaskIdFromCommitMessage(commit);
				string commitInfo = commit.Message.Replace(taskIdWithBrackets, string.Empty) + "   " + commit.Url;

				string taskId = taskIdWithBrackets.Replace("[", String.Empty).Replace("]", String.Empty);
				AddCheckListItemToTask(taskId, "Commits", commitInfo);
			}
		}

		private string GetTaskIdFromCommitMessage(Commit commit)
		{
			string pattern = @"\[(.*)\]";
			Regex rg = new Regex(pattern); 
			
			MatchCollection matchedStrings = rg.Matches(commit.Message);

			return matchedStrings.Count > 0 ? matchedStrings[0].Value : string.Empty;
		}
		
		private void AddCheckListItemToTask(string taskId, string checkListName, string checkListItemName)
		{
			string apiToken = "pk_8970047_OV7BUHRYTTCP0MRVEZYS8EC88S6IQVIO";
			
			ClickUpApiClient clickup = new ClickUpApiClient(apiToken);
			Task task = clickup.GetTask(taskId);
			if (task == null)
			{
				throw new Exception("Задача не была найдена");
			}
            
			Checklist checklist = task.GetChecklist(checkListName);
			if (checklist == null)
			{
				throw new Exception("Чеклист не был найден");
			}
            
			clickup.CreateCheckListItem(checklist.Id, checkListItemName, task.Assignees[0]);
            
		}
	}
}