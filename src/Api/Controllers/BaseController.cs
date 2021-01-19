using Microsoft.AspNetCore.Mvc;
#pragma warning disable 1591

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
    }
}