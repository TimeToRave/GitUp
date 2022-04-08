using System.Collections.Generic;
using System.Linq;
using GitUp.Interfaces;
using GitUp.Models.Clickup;
using Newtonsoft.Json;

namespace GitUp.Controllers
{
/// <summary>
    /// Отвечает за формирование запросов к API ClickUp
    /// </summary>
    class ClickUpApiClient : IApiClient
    {
        /// <summary>
        /// Адрес API ClickUp
        /// </summary>
        private const string ApiUrl = "https://api.clickup.com/api/v2";
        
        /// <summary>
        /// Пользовательский токен
        /// </summary>
        private readonly string PersonalApiToken;
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="personalApiToken">Пользовательский токен</param>
        public ClickUpApiClient(string personalApiToken)
        {
            PersonalApiToken = personalApiToken;
        }
        
        /// <summary>
        /// Подготавливает заголовки для запросов в ClickUp
        /// </summary>
        /// <param name="additionalHeaders"></param>
        /// <returns></returns>
        private Dictionary<string, string> PrepareHeaders(Dictionary<string, string> additionalHeaders = default)
        {
            
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                {"Authorization", PersonalApiToken}
            };

            additionalHeaders?.ToList().ForEach(x => headers.Add(x.Key, x.Value));

            return headers;
        }
        
        /// <summary>
        /// Получить данные о задаче
        /// </summary>
        /// <param name="taskId">Идентификатор задачи</param>
        /// <returns>Задача</returns>
        public Task GetTask(string taskId)
        {
            var response = SendGetRequestToClickUpApi("task", taskId);
            Task task = Task.Deserialize(response);
            return task;
        }
        
        /// <summary>
        /// Выполняет создание чеклиста в задаче
        /// </summary>
        /// <param name="checkListName">Название чек-листа. Может быть не уникальным</param>
        /// <param name="taskId">Идентификатор задачи</param>
        public void CreateCheckList(string checkListName, string taskId)
        {
            Dictionary<string, string> bodyDict = new Dictionary<string, string>
            {
                {"name", checkListName}
            };
            
            string body = ConvertDictionaryToJson(bodyDict);
            SendPostRequestToClickUpApi("task", taskId, "checklist", body);
        }

        /// <summary>
        /// Создание пункта в чеклисте
        /// </summary>
        /// <remarks>
        ///     Пример формируемой ссылки:
        ///     https://api.clickup.com/api/v2/checklist/checklist_id/checklist_item
        ///     При отправке запрос передается следующее тело запроса:
        ///     <code>
        ///         {
        ///             "name": "Checklist Item",
        ///             "assignee": 546
        ///         }
        ///     </code>
        /// </remarks>
        /// <param name="checkListId">Идентификатор чеклиста</param>
        /// <param name="checkListItemName">Название пункта чеклиста</param>
        /// <param name="assignee">Ответственный за пункт чеклиста</param>
        public void CreateCheckListItem(string checkListId, string checkListItemName, Assignee assignee = default)
        {
            Dictionary<string, string> bodyDict = new Dictionary<string, string>
            {
                {"name", checkListItemName}
            };
            
            if(assignee != null)
            {
                bodyDict.Add("assignee", assignee.Id.ToString());
            }
            
            string body = ConvertDictionaryToJson(bodyDict);
            SendPostRequestToClickUpApi("checklist", checkListId, "checklist_item", body);
        }
        
        /// <summary>
        /// Подготавливает и выполняет GET запрос в ClickUp 
        /// </summary>
        /// <remarks>
        ///     Пример формируемой ссылки:
        ///     https://api.clickup.com/api/v2/task/task_id
        /// </remarks>
        /// <param name="entityName">Название сущности, информация по которой будет запрошена</param>
        /// <param name="entityId">Идентификатор сущности</param>
        /// <param name="additionalHeaders">Дополнительные заголовки запроса</param>
        /// <returns></returns>
        private string SendGetRequestToClickUpApi(string entityName, string entityId, Dictionary<string, string> additionalHeaders = default)
        {
            var headers = PrepareHeaders(additionalHeaders);
            
            string methodUrl = $"{ApiUrl}/{entityName}/{entityId}";
            WebRequester requester = new WebRequester(methodUrl);

            string response = requester.GetRequest(additionalHeaders: headers);
            return response;
        }

        /// <summary>
        /// Подготавливает и выполняет POST запрос в ClickUp 
        /// </summary>
        /// <remarks>
        ///     Пример формируемой ссылки:
        ///     https://api.clickup.com/api/v2/list/list_id/task
        /// </remarks>
        /// <param name="entityName">Название родительской сущности, которая осуществляет связь</param>
        /// <param name="entityId">Идентификатор родительской сущности</param>
        /// <param name="additionalHeaders">Дополнительные заголовки запроса</param>
        /// <param name="postAction">Действие/название сущности, с которой будут выполняться действия</param>
        /// <returns></returns>
        private string SendPostRequestToClickUpApi(string entityName, string entityId, string postAction, string body, Dictionary<string, string> additionalHeaders = default)
        {
            var headers = PrepareHeaders(additionalHeaders);
            
            string methodUrl = $"{ApiUrl}/{entityName}/{entityId}/{postAction}";
            WebRequester requester = new WebRequester(methodUrl);

            return requester.PostRequest(body, additionalHeaders:headers);
        }
        
        /// <summary>
        /// Выполняет преобразование справочника в JSON
        /// </summary>
        /// <param name="dictionary">Справочник</param>
        /// <returns>JSON-строка</returns>
        private string ConvertDictionaryToJson(Dictionary<string, string> dictionary)
        {
            return JsonConvert.SerializeObject(dictionary);
        }
        
    }
}