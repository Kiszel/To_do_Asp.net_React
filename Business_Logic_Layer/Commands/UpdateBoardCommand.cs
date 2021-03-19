using Data_Access_Layer.Entities;
using Data_Access_Layer.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business_Logic_Layer.Commands
{
    public class UpdateBoardCommand : IRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Todo> Todos { get; set; }
    }
}
