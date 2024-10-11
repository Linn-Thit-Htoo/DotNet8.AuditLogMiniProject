namespace DotNet8.AuditLogMiniProject.Presentation.Features;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult Content(object obj)
    {
        return Content(obj.ToJson(), "application/json");
    }
}
