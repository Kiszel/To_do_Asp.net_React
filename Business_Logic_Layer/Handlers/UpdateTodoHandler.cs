using Business_Logic_Layer.Commands;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Handlers
{
    public class UpdateTodoHandler : IRequestHandler<UpdateTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;
        public UpdateTodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<Unit> Handle(UpdateTodoCommand request, CancellationToken cancellation)
        {
            var todo = new Todo
            {
                Id = request.Id,
                Date = request.Date,
                Description = request.Description,
                Priority = request.Priority,
                Title = request.Title
            };



            await _todoRepository.UpdateAsync(todo);
            return Unit.Value;
        }
    }
}
