using Mediatr.Contracts;

namespace Mediatr.Application;

public record EditTodoCommand(int Id, string Title, string Text) : ICommand<TodoDto>;
