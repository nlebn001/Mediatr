using MediatR;

namespace Mediatr.Application;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
