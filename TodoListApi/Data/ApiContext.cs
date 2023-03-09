using Microsoft.EntityFrameworkCore;
using TodoListApi.Models;

namespace TodoListApi.Data {
    public class ApiContext:DbContext {

        public DbSet<TodoList> Todos { get; set; }
        public ApiContext (DbContextOptions<ApiContext> options) : base(options) { }
    }
}
