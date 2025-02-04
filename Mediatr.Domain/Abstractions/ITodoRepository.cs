


namespace Mediatr.Domain;

public interface ITodoRepository
{
    void Add(Todo todo);
    Task<List<Todo>> AllTodosAsync(CancellationToken token = default);
    void Delete(Todo todo);
    Task<Todo> SingleAsync(int id, CancellationToken token = default);
    Task<Todo?> SingleOrDefaultAsync(int id, CancellationToken token = default);
}
