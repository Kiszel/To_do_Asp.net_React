using Data_Access_Layer.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer.Commands
{
    public class CreateBoardCommand : IRequest
    {
        public string Title { get; set; }
    }
}
