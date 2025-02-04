using Mediatr.Contracts;
using Mediatr.Domain;

namespace Mediatr.Application;

internal sealed class EditTodoCommandHandler(ITodoRepository todoRepo, IUnitOfWork unitOfWork) : ICommandHandler<EditTodoCommand, TodoDto>
{
    private readonly ITodoRepository _todoRepo = todoRepo;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<TodoDto> Handle(EditTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = (await _todoRepo.SingleAsync(request.Id, cancellationToken))!;

        todo.Title = request.Title;
        todo.Text = request.Text;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
        var todoDto = new TodoDto(todo.Id, todo.Title, todo.Text);

        return todoDto;
    }
}
