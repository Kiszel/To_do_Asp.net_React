using Data_Access_Layer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer.Queries
{
    public class GetBoardQuery : IRequest<Board>
    {
            public int Id { get; set; }
    }
}
