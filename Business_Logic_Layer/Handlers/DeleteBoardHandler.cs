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
    public class DeleteBoardHandler : IRequestHandler<DeleteBoardCommand>
    {
        private readonly IBoardRepository _boardRepository;
        public DeleteBoardHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        public async Task<Unit> Handle(DeleteBoardCommand request, CancellationToken cancellation)
        {
            await _boardRepository.DeleteEntityAsync(request.Id);
            return Unit.Value;
        }
    }
}
