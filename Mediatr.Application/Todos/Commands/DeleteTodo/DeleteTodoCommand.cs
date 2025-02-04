namespace Mediatr.Application;

public sealed record DeleteTodoCommand(int Id) : ICommand<int>;
