using Microsoft.EntityFrameworkCore;
using ToDo_List.Data;
using ToDo_List.Models;

namespace ToDo_List.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly ToDoContext _context;
        public TodoRepository(ToDoContext context)
        {
            this._context = context;
        }
        public async Task<TaskItem> AddTaskAsync(TaskItem task)
        {
            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTaskByIdAsync(int id)
        {
            var item = await _context.TaskItems.FindAsync(id);
            if (item != null)
            {
                _context.TaskItems.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<TaskItem>> GetAllTasksAsync()
        {
            return await _context.TaskItems.ToListAsync();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(int id)
        {
            return await _context.TaskItems.FindAsync(id);
        }

        public async Task<bool> UpdateTask(TaskItem task)
        {
            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
