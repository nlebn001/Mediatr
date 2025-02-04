namespace Mediatr.Application;

public sealed record CreateTodoCommand(string Title, string Text) : ICommand<int>;
