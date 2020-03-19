using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.EF;
using Todo.EF.Models;

namespace Todo.Api.Controllers
{
    [Route("api/todo")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class TodoController : ControllerBase
    {
        private TodoDBContext _todoDBContext;
        public TodoController(TodoDBContext todoDBContext)
        {
            _todoDBContext = todoDBContext;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var todos = this._todoDBContext.Todos;

            return Ok(todos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var todos = this._todoDBContext.Todos.Where(d => d.id == id).First();

            if (todos == null)
                return BadRequest("Provide Valid ID");

            return Ok(todos);
        }

        public IActionResult Post(Todo.EF.Models.Todo todo) {
            this._todoDBContext.Add(todo);
            this._todoDBContext.SaveChanges();
            return Ok(todo);
        }
    }
}