using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Repositories
{
    public interface ITodoRepository
    {
        Todo GetTodo(Guid id);
        IEnumerable<Todo> GetAllTodo();
        Todo AddTodo(Todo todo);
        Todo Update(Todo todoChanges);
        Todo Delete(Guid id);

        


    }
}
