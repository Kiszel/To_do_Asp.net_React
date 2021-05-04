using Business_Logic_Layer.Commands;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Handlers.BoardHandler
{
    public class UpdateBoardsHandler : IRequestHandler<UpdateBoardsCommand>
    {
        private readonly IBoardRepository _boardRepository;
        public UpdateBoardsHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        public async Task<Unit> Handle(UpdateBoardsCommand request, CancellationToken cancellation)
        {

             await _boardRepository.UpdateRangeEntityAsync(request.boards);
            return Unit.Value;
        }
    }
}
