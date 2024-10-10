﻿using DotNet8.AuditLogMiniProject.Domain.Features.Blog;
using DotNet8.AuditLogMiniProject.DTOs.Features.Blog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.AuditLogMiniProject.Presentation.Features.Blog
{
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
        public async Task<IActionResult> CreateBlog([FromBody] BlogRequestDTO blogRequest, CancellationToken cs)
        {
            var result = await _blogService.AddBlogAsync(blogRequest, cs);
            return Content(result);
        }
    }
}
