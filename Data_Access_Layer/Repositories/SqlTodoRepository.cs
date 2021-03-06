using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Repositories
{
    public class SqlTodoRepository : ITodoRepository
    {
        private readonly DataContext _dataContext;
        public SqlTodoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public Todo AddTodo(Todo todo)
        {
            _dataContext.Todos.Add(todo);
            _dataContext.SaveChanges();
            return todo;
        }

        public Todo Delete(Guid id)
        {
            var todo = _dataContext.Todos.Find(id);
            if (todo != null)
            {
                _dataContext.Todos.Remove(todo);
                _dataContext.SaveChanges();
            }
            return todo;
        }

        public IEnumerable<Todo> GetAllTodo()
        {
            return _dataContext.Todos;
        }

        public Todo GetTodo(Guid id)
        {
            return _dataContext.Todos.Find(id);
        }

        public Todo Update(Todo todoChanges)
        {
            var todo = _dataContext.Todos.Attach(todoChanges);
            todo.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dataContext.SaveChanges();
            return todoChanges;
        }
    }
}
