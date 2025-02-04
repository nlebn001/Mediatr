using Mediatr.Contracts;
using Mediatr.Domain;

namespace Mediatr.Application;

internal sealed class CreateTodoCommandHandler(ITodoRepository todoRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateTodoCommand, int>
{
    private readonly ITodoRepository _todoRepository = todoRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<int> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Todo { Text = request.Text, Title = request.Title };
        _todoRepository.Add(todo);
        await _unitOfWork.SaveChangesAsync();

        return todo.Id;
    }
}
