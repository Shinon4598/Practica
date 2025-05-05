using AutoMapper;
using ToDo_List.Models;
using ToDo_List.Models.dto;
using ToDo_List.Repository;

namespace ToDo_List.Services
{
    public class ToDoServices : IToDoService
    {
        private readonly ITodoRepository _toDoRepository;
        private readonly IMapper _mapper; 
        public ToDoServices(ITodoRepository toDoRepository, IMapper mapper)
        {
            this._toDoRepository = toDoRepository;
            _mapper = mapper;
        }
        public async Task<TaskItemDTO> AddTaskAsync(TaskCreateDTO dto)
        {
            var task = _mapper.Map<TaskItem>(dto);

            await _toDoRepository.AddTaskAsync(task);

            return _mapper.Map<TaskItemDTO>(task);
        }

        public async Task<bool> DeleteTaskByIdAsync(int id)
        {
            return await _toDoRepository.DeleteTaskByIdAsync(id);
        }

        public async Task<List<TaskItemDTO>> GetAllTasksAsync()
        {
            var tasks = await _toDoRepository.GetAllTasksAsync();
            return _mapper.Map<List<TaskItemDTO>>(tasks);
        }

        public async Task<TaskItemDTO?> GetTaskByIdAsync(int id)
        {
            var task = await _toDoRepository.GetTaskByIdAsync(id);
            return task != null ? _mapper.Map<TaskItemDTO>(task) : null;
        }

        public async Task<bool> UpdateTask(int id, TaskUpdateDTO dto)
        {
            var task = await _toDoRepository.GetTaskByIdAsync(id);
            if (task == null)
            {
                return false;
            }

            // Actualizar solo los campos que se enviaron en el dto
            task.Name = dto.Name ?? task.Name;
            task.IsCompleted = dto.IsCompleted;

           
            return await _toDoRepository.UpdateTask(task);

        }
    }
}
