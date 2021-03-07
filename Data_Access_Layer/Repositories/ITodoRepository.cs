using Data_Access_Layer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer.Repositories
{
    public interface ITodoRepository
    {
        Task<Todo> GetTodoAsync(Guid id);
        Task<IEnumerable<Todo>> GetAllTodoAsync();
        Task<Todo> AddTodoAsync(Todo todo);
        Task<Todo> UpdateAsync(Todo todoChanges);
        Task<Todo> DeleteAsync(Guid id);

    }
}
