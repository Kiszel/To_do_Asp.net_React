using System.Collections.Generic;
using System.Threading.Tasks;
using Business_Logic_Layer.Queries;
using Data_Access_Layer.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using Business_Logic_Layer.Commands;

namespace Todo_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BoardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetAllBoardsAsync()
        {
            var query = new GetAllBoardsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Todo>>> GetBoardAsync(int id)
        {
            var query = new GetBoardQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateBoardCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(int id)
        {
            var command = new DeleteBoardCommand() { Id = id };
            return await _mediator.Send(command);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(int id, UpdateBoardCommand command)
        {
            command.Id = id;
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<ActionResult<Unit>> EditBoards([FromBody]List<Board> boards)
        {
            var command = new UpdateBoardsCommand()
            {
                boards = boards
            };
            return await _mediator.Send(command);
        }
    }
}
