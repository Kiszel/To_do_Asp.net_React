using Business_Logic_Layer.Queries;
using Data_Access_Layer.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Data_Access_Layer.Entities;

namespace Business_Logic_Layer.Handlers.BoardHandler
{
    public class GetBoardHandler : IRequestHandler<GetBoardQuery,Board>
    {
        private readonly IBoardRepository _boardRepository;
        public GetBoardHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        public async Task<Board> Handle(GetBoardQuery request, CancellationToken cancellationToken)
        {
            var board = await _boardRepository.GetEntityAsync(request.Id);
            return board;
        }
    }
}
