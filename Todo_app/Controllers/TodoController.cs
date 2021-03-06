using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Access_Layer;
using Microsoft.AspNetCore.Mvc;

namespace Todo_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly DataContext _context;
        public TodoController(DataContext context)
        {
            _context = context;
        }
    }
}
