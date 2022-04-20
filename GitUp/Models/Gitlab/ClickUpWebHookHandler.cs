﻿using GitUp.Controllers;
using GitUp.Interfaces;
using GitUp.Models.Clickup;
using System;
using System.Text.RegularExpressions;

namespace GitUp.Models.Gitlab
{
	public class ClickUpWebHookHandler : IWebHookHandler
	{
		private readonly string ApiToken;
		public ClickUpWebHookHandler(string apiToken)
		{
			if (apiToken is object && apiToken.Length > 0)
			{
				ApiToken = apiToken;
			} 
			else
			{
				throw new Exception("Invalid API token");
			}
		}


		public void HandlePushEvent(WebHook webHook)
		{
			string checkListName = "Commits";
			foreach (var commit in webHook.Commits)
			{
				string taskIdWithBrackets = GetTaskIdFromCommitMessage(commit);
				string commitInfo = commit.Message.Replace(taskIdWithBrackets, string.Empty) + "   " + commit.Url;

				string taskId = taskIdWithBrackets.Replace("[", String.Empty).Replace("]", String.Empty);
				Checklist checkList = CreateChecklistIfNotExists(checkListName, taskId);
				AddCheckListItemToTask(taskId, checkList.Name, commitInfo);
			}
		}

		private Checklist CreateChecklistIfNotExists(string checkListName, string taskId)
		{
			IApiClient clickup = new ClickUpApiClient(ApiToken);
			return clickup.CreateChecklistIfNotExitsts(taskId, checkListName);

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
			IApiClient clickup = new ClickUpApiClient(ApiToken);
			clickup.AddUniqueCheckListItemToTask(taskId, checkListName, checkListItemName);
		}

	}
}
