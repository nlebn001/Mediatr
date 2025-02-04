
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Mediatr.Presentation;

//[ApiController]
//[Route("api/[controller]")]
//public abstract class ApiControllerBase : ControllerBase
//{
//    protected ISender Sender { get; init; }

//    public ApiControllerBase()
//    {
//        Sender ??= HttpContext.RequestServices.GetService<ISender>() ??
//            throw new NullReferenceException($"{nameof(ISender)} service not found");
//    }

//}

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    protected ISender Sender { get; }

    protected ApiControllerBase(ISender sender)
    {
        Sender = sender ?? throw new ArgumentNullException(nameof(sender));
    }
}