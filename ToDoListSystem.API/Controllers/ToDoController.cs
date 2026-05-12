using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoListSystem.Application.ToDoItems.Commands.CreateToDoItem;
using ToDoListSystem.Application.ToDoItems.Commands.DeleteToDoItem;
using ToDoListSystem.Application.ToDoItems.Commands.UpdateToDoItem;
using ToDoListSystem.Application.ToDoItems.Queries;
using ToDoListSystem.Application.ToDoItems.Queries.GetToDoItems;

namespace ToDoListSystem.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ToDoController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateToDoItemCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<List<ToDoItemDto>>> GetAll()
        {
            return await _mediator.Send(new GetToDoItemsQuery());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateToDoItemCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeleteToDoItemCommand(id));

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
