using Mediatr.Domain;

namespace Mediatr.Application;

public sealed class ValidationException : AppBadRequestException
{
    public Dictionary<string, string[]> Errors { get; }
    public ValidationException(Dictionary<string, string[]> errors) : base("Validation errors occured")
    {
        Errors = errors;
    }
}
