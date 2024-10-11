namespace DotNet8.AuditLogMiniProject.Presentation.Features.Blog;

[Route("api/[controller]")]
[ApiController]
public class BlogController : BaseController
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog(
        [FromBody] BlogRequestDTO blogRequest,
        CancellationToken cs
    )
    {
        var result = await _blogService.AddBlogAsync(blogRequest, cs);
        return Content(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlog(
        [FromBody] BlogRequestDTO blogRequest,
        int id,
        CancellationToken cs
    )
    {
        var result = await _blogService.UpdateBlogAsync(blogRequest, id, cs);
        return Content(result);
    }
}
