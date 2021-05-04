using Business_Logic_Layer.Queries;
using Data_Access_Layer.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Data_Access_Layer.Entities;

namespace Business_Logic_Layer.Handlers.TodoHandler
{
    public class GetAllTodosHandler : IRequestHandler<GetAllTodosQuery, List<Todo>>
    {
        private readonly ITodoRepository _todoRepository;
        public GetAllTodosHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<List<Todo>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
        {
            var todos = await _todoRepository.GetAllEntityAsync();
            return todos.ToList();
        }
    }
}
