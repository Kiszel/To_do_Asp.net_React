using Data_Access_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _dataContext;
        public TodoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<Todo> AddTodoAsync(Todo todo)
        {
            _dataContext.Todos.Add(todo);
            await _dataContext.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo> DeleteAsync(Guid id)
        {
            var todo = await _dataContext.Todos.FindAsync(id);
            if (todo != null)
            {
                _dataContext.Todos.Remove(todo);
                await _dataContext.SaveChangesAsync();
            }
            return todo;
        }

        public async Task<IEnumerable<Todo>> GetAllTodoAsync()
        {
            var todos = await _dataContext.Todos.ToListAsync();
            return todos;
        }

        public async Task<Todo> GetTodoAsync(Guid id)
        {
            var todo = await _dataContext.Todos.FindAsync(id);
            return todo;
        }

        public async Task<Todo> UpdateAsync(Todo todoChanges)
        {
            var todo = await _dataContext.Todos.FindAsync(todoChanges.Id);
            todo.Title = todoChanges.Title;
            todo.Description = todoChanges.Description;
            todo.Priority = todoChanges.Priority;
            todo.Date = todoChanges.Date;
            await _dataContext.SaveChangesAsync();
            return todoChanges;
        }
    }
}
