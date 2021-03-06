using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Access_Layer;
using Data_Access_Layer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Todo_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;
        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }
    }
}
