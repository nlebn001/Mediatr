namespace Mediatr.Domain;

public class Todo : Entity
{
    public string Title { get; set; } = null!;
    public string Text { get; set; } = null!;
}
