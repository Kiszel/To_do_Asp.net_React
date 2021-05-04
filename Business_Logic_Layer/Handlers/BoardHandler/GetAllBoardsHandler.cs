using Business_Logic_Layer.Queries;
using Data_Access_Layer.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Data_Access_Layer.Entities;

namespace Business_Logic_Layer.Handlers.BoardHandler
{
    public class GetAllBoardsHandler : IRequestHandler<GetAllBoardsQuery, List<Board>>
    {
        private readonly IBoardRepository _boardRepository;
        public GetAllBoardsHandler(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }
        public async Task<List<Board>> Handle(GetAllBoardsQuery request, CancellationToken cancellationToken)
        {
            var boards = await _boardRepository.GetAllEntityAsync();
            return boards.ToList();
        }
    }
}
