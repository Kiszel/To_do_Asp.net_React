using Business_Logic_Layer.Queries;
using Data_Access_Layer.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Data_Access_Layer.Entities;

namespace Business_Logic_Layer.Handlers
{
    public class GetTodoHandler : IRequestHandler<GetTodoQuery,Todo>
    {
        private readonly ITodoRepository _todoRepository;
        public GetTodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<Todo> Handle(GetTodoQuery request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetEntityAsync(request.Id);
            return todo;
        }
    }
}
