using Data_Access_Layer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer.Queries
{
    public class GetAllBoardsQuery : IRequest<List<Board>> { }
}
