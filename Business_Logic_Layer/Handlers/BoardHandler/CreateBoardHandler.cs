using Business_Logic_Layer.Commands;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Handlers.BoardHandler
{
    public class CreateBoardHandler : IRequestHandler<CreateBoardCommand>
    {
        private readonly IBoardRepository _boardRepository;
        public CreateBoardHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        public async Task<Unit> Handle(CreateBoardCommand request, CancellationToken cancellationToken)
    {
        var board = new Board
        {
            Title = request.Title,
        };
            await _boardRepository.AddEntityAsync(board);
            return Unit.Value;
        }
    }
}

