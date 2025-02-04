
using Mediatr.Domain;

namespace Mediatr.Application;
internal sealed class DeleteTodoCommandHandler(ITodoRepository todoRepo, IUnitOfWork unitOfWork) : ICommandHandler<DeleteTodoCommand, int>
{
    private readonly ITodoRepository _todoRepo = todoRepo;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<int> Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepo.SingleAsync(request.Id, cancellationToken);
        _todoRepo.Delete(todo);
        await _unitOfWork.SaveChangesAsync();

        return todo.Id;
    }
}
