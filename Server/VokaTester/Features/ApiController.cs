namespace VokaTester.Features
{
    using Microsoft.AspNetCore.Mvc;

    using static VokaTester.Infrastructure.WebConstants;

    [ApiController]
    [Route(DefaultRoute)]
    public abstract class ApiController : ControllerBase
    {
    }
}
