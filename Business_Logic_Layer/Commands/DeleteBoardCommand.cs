using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer.Commands
{
    public class DeleteBoardCommand : IRequest
    {
        public int Id { get; set; }
    }
}
