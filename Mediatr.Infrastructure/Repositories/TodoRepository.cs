using Mediatr.Domain;
using Microsoft.EntityFrameworkCore;

namespace Mediatr.Persistence;

public sealed class TodoRepository : ITodoRepository
{
    private readonly DbSet<Todo> _todoSet;

    public TodoRepository(AppDbContext context)
    {
        _todoSet = context.Set<Todo>();
    }

    public void Add(Todo todo) => _todoSet.Add(todo);
    public async Task<Todo?> SingleOrDefaultAsync(int id, CancellationToken token = default) =>
        await _todoSet.SingleOrDefaultAsync(x => x.Id == id, token);
    public async Task<Todo> SingleAsync(int id, CancellationToken token = default) =>
        await _todoSet.SingleOrDefaultAsync(x => x.Id == id, token) ?? throw new AppNotFoundException($"{nameof(Todo)} with Id {id} not found");
    public async Task<List<Todo>> AllTodosAsync(CancellationToken token = default) => await _todoSet.ToListAsync(token);
    public void Delete(Todo todo) => _todoSet.Remove(todo);
}
