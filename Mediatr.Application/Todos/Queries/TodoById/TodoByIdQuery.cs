using Mediatr.Contracts;

namespace Mediatr.Application;
public sealed record TodoByIdQuery(int Id) : IQuery<TodoDto>;
