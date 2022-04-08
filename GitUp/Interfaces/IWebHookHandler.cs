using GitUp.Models.Gitlab;

namespace GitUp.Interfaces
{
    public interface IWebHookHandler
    {
        void HandlePushEvent(WebHook webHook);
    }
}