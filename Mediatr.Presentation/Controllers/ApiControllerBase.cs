
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mediatr.Presentation;

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