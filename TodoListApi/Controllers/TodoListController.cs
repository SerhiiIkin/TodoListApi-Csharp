using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListApi.Models;
using TodoListApi.Data;
using Microsoft.EntityFrameworkCore;


namespace TodoListApi.Controllers {
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TodoListController : ControllerBase {
        private readonly ApiContext _context;

        public TodoListController(ApiContext context) {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoList todo) {

            todo.Id = Guid.NewGuid();

            await _context.Todos.AddAsync(todo);

            await _context.SaveChangesAsync();

            return Ok(todo);
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id) {
            var result = await _context.Todos.FindAsync(id);

            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id) {
            var result = await _context.Todos.FindAsync(id);

            if (result == null)
                return NotFound();

            _context.Todos.Remove(result);
           await _context.SaveChangesAsync();
            
            return Ok(result);
        }

        [HttpGet]
        public async  Task<IActionResult> GetAll() {
            var result = await _context.Todos.ToListAsync();

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTodo(Guid id, TodoList todo) {
            var result = await _context.Todos.FindAsync(id);

            if (result == null)
                return NotFound();


            result.Description = todo.Description;
            result.IsDone = todo.IsDone;

            await _context.SaveChangesAsync();

            return Ok(result);

        }
    }

   
}
