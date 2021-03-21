using Data_Access_Layer.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer.Commands
{
    public class UpdateBoardsCommand:IRequest
    {
        public List<Board> boards { get; set; }
    }
}
