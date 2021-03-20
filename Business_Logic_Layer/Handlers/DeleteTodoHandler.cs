using Business_Logic_Layer.Commands;
using Data_Access_Layer.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Handlers
{
    public class DeleteTodoHandler : IRequestHandler<DeleteoTodoCommand>
    {
        private readonly ITodoRepository _todoRepository;
        public DeleteTodoHandler(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
        public async Task<Unit> Handle(DeleteoTodoCommand request, CancellationToken cancellation)
        {
            await _todoRepository.DeleteEntityAsync(request.Id);
            return Unit.Value;
        }
    }
}
