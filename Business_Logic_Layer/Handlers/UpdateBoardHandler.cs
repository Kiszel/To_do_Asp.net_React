using Business_Logic_Layer.Commands;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Handlers
{
    public class UpdateBoardHandler : IRequestHandler<UpdateBoardCommand>
    {
        private readonly IBoardRepository _boardRepository;
        public UpdateBoardHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        public async Task<Unit> Handle(UpdateBoardCommand request, CancellationToken cancellation)
        {
            var board = new Board
            {
                Id = request.Id,
                Title = request.Title,
                Todos=request.Todos,
            };
            await _boardRepository.UpdateEntityAsync(board);
            return Unit.Value;
        }
    }
}
