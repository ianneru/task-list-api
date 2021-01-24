using Microsoft.AspNetCore.Mvc;

namespace TaskList.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : Controller
    {
    }
}
