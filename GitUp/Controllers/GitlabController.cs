using System;
using GitUp.Interfaces;
using GitUp.Models.Gitlab;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GitUp.Controllers
{
	[ApiController]
	[Route("api/v1/[controller]/push")]
	public class GitlabController : ControllerBase
	{
		private readonly ILogger<GitlabController> _logger;
		private readonly IConfiguration _config;

		public GitlabController(ILogger<GitlabController> logger, IConfiguration config)
		{
			_logger = logger;
			_config = config;
		}

		[HttpPost]
        [AcceptVerbs("POST")]
        public string Post([FromBody] WebHook webHook)
		{
			IWebHookHandler handler = new ClickUpWebHookHandler(_config["ClickUpAccessToken"]);
			handler.HandlePushEvent(webHook);
			
			return String.Empty;
		}
	}
}