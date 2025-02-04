using Mediatr.Contracts;
using Mediatr.Domain;

namespace Mediatr.Application.Todos.Queries.TodoById;

internal sealed class TodoByIdQueryHandler(ITodoRepository todoRepo) : IQueryHandler<TodoByIdQuery, TodoDto>
{
    public async Task<TodoDto> Handle(TodoByIdQuery request, CancellationToken cancellationToken)
    {
        var todo = await todoRepo.SingleOrDefaultAsync(request.Id, cancellationToken) ??
            throw new AppNotFoundException($"{nameof(Todo)} with Id {request.Id} not found");

        var todoDto = new TodoDto(todo.Id, todo.Title, todo.Text);

        return todoDto;
    }
}
