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
    public class TodoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TodoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<Todo>>> GetAllTodosAsync()
        {
            var query = new GetAllTodosQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Todo>>> GetTodoAsync(Guid id)
        {
            var query = new GetTodoQuery() { Id = id };
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Create(CreateTodoCommand command)
        {
            return await _mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            var command = new DeleteoTodoCommand() { Id = id };
            return await _mediator.Send(command);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Edit(Guid id, UpdateTodoCommand command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
    }
}
