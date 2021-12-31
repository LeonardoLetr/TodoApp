using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class TodosController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<TodoItem> GetAll(
           [FromServices] ITodoRepository repository)
        {
            return repository.GetAll("LeonardoGeraldo");
        }

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone(
           [FromServices] ITodoRepository repository)
        {
            return repository.GetAllDone("LeonardoGeraldo");
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUndone(
           [FromServices] ITodoRepository repository)
        {
            return repository.GetAllUndone("LeonardoGeraldo");
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForToday(
           [FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod(
                "LeonardoGeraldo",
                DateTime.Now.Date,
                true);
        }

        [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetInactiveForToday(
           [FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod(
                "LeonardoGeraldo",
                DateTime.Now.Date,
                false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetDoneForTomorrow(
           [FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod(
                "LeonardoGeraldo",
                DateTime.Now.Date.AddDays(1),
                true);
        }

        [Route("undone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetInactiveForTomorrow(
           [FromServices] ITodoRepository repository)
        {
            return repository.GetByPeriod(
                "LeonardoGeraldo",
                DateTime.Now.Date.AddDays(1),
                false);
        }

        [HttpPost]
        public GenericCommandResult Create(
            [FromBody] CreateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = "LeonardoGeraldo";
            return (GenericCommandResult) handler.Handle(command);
        }

        [HttpPut]
        public GenericCommandResult Create(
            [FromBody] UpdateTodoCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = "LeonardoGeraldo";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult MarkAsDone(
            [FromBody] MarkTodoAsDoneCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = "LeonardoGeraldo";
            return (GenericCommandResult)handler.Handle(command);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult MarkAsUndone(
            [FromBody] MarkTodoAsUndoneCommand command,
            [FromServices] TodoHandler handler)
        {
            command.User = "LeonardoGeraldo";
            return (GenericCommandResult)handler.Handle(command);
        }
    }
}
