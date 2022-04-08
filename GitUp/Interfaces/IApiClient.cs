using GitUp.Models.Clickup;

namespace GitUp.Interfaces
{
    /// <summary>
    /// Описывает интерфейс взаимодействия с API ClickUp
    /// </summary>
    public interface IApiClient
    {
        /// <summary>
        /// Получить данные о задаче
        /// </summary>
        /// <param name="taskId">Идентификатор задачи</param>
        /// <returns>Задача</returns>
        Task GetTask(string taskId);

        /// <summary>
        /// Выполняет создание чеклиста в задаче
        /// </summary>
        /// <param name="checkListName">Название чек-листа. Может быть не уникальным</param>
        /// <param name="taskId">Идентификатор задачи</param>
        void CreateCheckList(string checkListName, string taskId);
        
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
        void CreateCheckListItem(string checkListId, string checkListItemName, Assignee assignee = default);
    }
}