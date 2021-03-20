using Business_Logic_Layer.Commands;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Handlers
{
    public class CreateTodoHandler : IRequestHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;
        public CreateTodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<Unit> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Todo
        {
            Title = request.Title,
            Description = request.Description,
            Priority = request.Priority,
            Date = request.Date,
        };
            await _todoRepository.AddEntityAsync(todo);
            return Unit.Value;
        }
    }
}

