using Mediatr.Contracts;

namespace Mediatr.Application;

public sealed record AllTodosQuery() : IQuery<IEnumerable<TodoDto>>;

