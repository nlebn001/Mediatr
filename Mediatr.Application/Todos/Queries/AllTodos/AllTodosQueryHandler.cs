using Mediatr.Contracts;
using Mediatr.Domain;

namespace Mediatr.Application;

internal sealed class AllTodosQueryHandler(ITodoRepository todoRepo) : IQueryHandler<AllTodosQuery, IEnumerable<TodoDto>>
{
    private readonly ITodoRepository _todoRepository = todoRepo;
    public async Task<IEnumerable<TodoDto>> Handle(AllTodosQuery request, CancellationToken cancellationToken)
    {
        var allTodos = (await _todoRepository.AllTodosAsync(cancellationToken))
            .Select(x => new TodoDto(x.Id, x.Title, x.Text));

        return allTodos;
    }
}
