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
        private readonly IBoardRepository _boardRepository;
        public CreateTodoHandler(ITodoRepository todoRepository, IBoardRepository boardRepository)
        {
            _todoRepository = todoRepository;
            _boardRepository = boardRepository;
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
            var entityTodo = await _todoRepository.AddEntityAsync(todo);
            await _boardRepository.AddTodoToBoard(entityTodo);
            return Unit.Value;
        }
    }
}

