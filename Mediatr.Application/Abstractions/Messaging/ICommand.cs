using MediatR;

namespace Mediatr.Application;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}

