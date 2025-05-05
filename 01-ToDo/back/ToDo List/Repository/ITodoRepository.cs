using ToDo_List.Models;

namespace ToDo_List.Repository
{
    public interface ITodoRepository
    {
        Task<List<TaskItem>> GetAllTasksAsync();
        Task<TaskItem?> GetTaskByIdAsync(int id);
        Task<TaskItem> AddTaskAsync(TaskItem task);
        Task<bool> UpdateTask(TaskItem task);
        Task<bool> DeleteTaskByIdAsync(int id);
    }
}
