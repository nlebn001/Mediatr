using Mediatr.Application;
using Mediatr.Contracts;
using Mediatr.TodoContracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mediatr.Presentation;

public sealed class TodoController : ApiControllerBase
{
    public TodoController(ISender sender) : base(sender)
    {
    }

    [HttpGet("alltodos")]
    [ProducesResponseType(typeof(TodoDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> AllTodosAsync(int todoId, CancellationToken token)
    {
        var query = new AllTodosQuery();
        var todo = await Sender.Send(query, token);
        return Ok(todo);
    }

    [HttpGet("todo/{todoId:int}")]
    [ProducesResponseType(typeof(TodoDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> TodoAsync(int todoId, CancellationToken token)
    {
        var query = new TodoByIdQuery(todoId);
        var todo = await Sender.Send(query, token);
        return Ok(todo);
    }

    [HttpPost("createtodo")]
    [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTodoAsync([FromBody] CreateTodoDto todo, CancellationToken token)
    {
        var command = new CreateTodoCommand(todo.Title, todo.Text);
        var todoId = await Sender.Send(command, token);
        return CreatedAtAction(nameof(CreateTodoAsync), todoId);
    }

    [HttpPut("edittodo/{todoId:int}")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> EditTodoAsync(int todoId, [FromBody] EditTodoDto todo, CancellationToken token)
    {
        var command = new EditTodoCommand(todoId, todo.Title, todo.Text);
        var todoDto = await Sender.Send(command, token);
        return Ok(todoDto);
    }

    [HttpDelete("deletetodo/{todoId:int}")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTodoAsync(int todoId, CancellationToken token)
    {
        var command = new DeleteTodoCommand(todoId);
        var deletedTodoId = await Sender.Send(command, token);
        return Ok(deletedTodoId);
    }
}
