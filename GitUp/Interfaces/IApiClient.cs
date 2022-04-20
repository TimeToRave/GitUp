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
        Checklist CreateCheckList(string checkListName, string taskId);
        
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
		
        /// <summary>
        /// Выполняет проверку наличия чеклиста в задаче
        /// Если чеклист с таким именем отсутсвтует, 
        /// то создает его
        /// </summary>
        /// <param name="taskId">Идентификатор зачачи</param>
        /// <param name="checkListName">Название чеклиста</param>
        /// <returns>Чеклист</returns>
        Checklist CreateChecklistIfNotExitsts(string taskId, string checkListName);

		/// <summary>
		/// Выполняет проверку на наличие
		/// чеклиста в задаче
		/// </summary>
		/// <param name="taskId">Идентификатор задачи</param>
		/// <param name="checkListName">Название чеклиста</param>
		/// <returns>Чеклист</returns>
		Checklist GetCheckList(string taskId, string checkListName);

        /// <summary>
        /// Создает пункт чеклиста
        /// </summary>
        /// <param name="taskId">Идентификатор задачи</param>
        /// <param name="checkListName">Название чеклиста в задаче</param>
        /// <param name="checkListItemName">Новый пункт чеклиста</param>
        void AddCheckListItemToTask(string taskId, string checkListName, string checkListItemName);

        /// <summary>
        /// Создание пункта в чеклисте, который не повторялся бы ранее
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
        /// <param name="taskId">Идентификатор чеклиста</param>
        /// <param name="checkListId">Идентификатор чеклиста</param>
        /// <param name="checkListItemName">Название пункта чеклиста</param>
        /// <param name="assignee">Ответственный за пункт чеклиста</param>
        public void AddUniqueCheckListItemToTask(string taskId, string checkListName, string checkListItemName);


    }
}