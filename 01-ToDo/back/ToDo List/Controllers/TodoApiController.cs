using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo_List.Data;
using ToDo_List.Models;
using ToDo_List.Models.dto;
using ToDo_List.Repository;
using ToDo_List.Services;

namespace ToDo_List.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoApiController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public TodoApiController(IToDoService toDoService)
        {
            this._toDoService = toDoService;
        }

        // GET: api/TodoApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemDTO>>> GetAllTasks()
        {
           return await this._toDoService.GetAllTasksAsync();
        }

        // GET: api/TodoApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDTO>> GetTaskById(int id)
        {
            var taskItem = await _toDoService.GetTaskByIdAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            return taskItem;
        }
        // POST: api/TodoApi
        [HttpPost]
        public async Task<ActionResult<TaskItemDTO>> AddTask(TaskCreateDTO task)
        {
            var createddto = await _toDoService.AddTaskAsync(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = createddto.Id }, task);
        }
        //PUT : api/TodoApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskUpdateDTO task)
        {
            try
            {
                await _toDoService.UpdateTask(id, task);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await _toDoService.GetTaskByIdAsync(id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }
        // DELETE: api/TodoApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _toDoService.DeleteTaskByIdAsync(id);
            return NoContent();
        }
    }
}
