using FluentValidation;

namespace Mediatr.Application;

public sealed class EditTodoCommandValidator : AbstractValidator<EditTodoCommand>
{
    public EditTodoCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Text).NotEmpty();
    }
}
