namespace Mediatr.Domain;

public abstract class AppBadRequestException : Exception
{
    protected AppBadRequestException(string message) : base(message) { }
}
