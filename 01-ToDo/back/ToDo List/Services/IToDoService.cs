using ToDo_List.Models.dto;

namespace ToDo_List.Services
{
    public interface IToDoService
    {
        Task<List<TaskItemDTO>> GetAllTasksAsync();
        Task<TaskItemDTO?> GetTaskByIdAsync(int id);
        Task<TaskItemDTO> AddTaskAsync(TaskCreateDTO dto);
        Task<bool> UpdateTask(int id,TaskUpdateDTO task);
        Task<bool> DeleteTaskByIdAsync(int id);
    }
}
