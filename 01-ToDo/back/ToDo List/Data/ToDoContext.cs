using Microsoft.EntityFrameworkCore;
using ToDo_List.Models;

namespace ToDo_List.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }
        public DbSet<TaskItem> TaskItems { get; set; }
      

    }
}
