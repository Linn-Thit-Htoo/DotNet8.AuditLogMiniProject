using DotNet8.AuditLogMiniProject.Domain.Features.Blog;
using DotNet8.AuditLogMiniProject.DTOs.Features.Blog;
using DotNet8.AuditLogMiniProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.AuditLogMiniProject.Infrastructure.Features.Blog
{
    public class BlogService : IBlogService
    {
        private readonly AppDbContext _context;
        public Task<Result<BlogDTO>> AddBlogAsync(BlogRequestDTO blogRequest, CancellationToken cs)
        {
            throw new NotImplementedException();
        }
    }
}
