namespace Mediatr.Domain;

public sealed class AppNotFoundException : Exception
{
    public AppNotFoundException(string message) : base(message) { }
}
