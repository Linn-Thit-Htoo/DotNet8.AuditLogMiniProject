using DotNet8.AuditLogMiniProject.Domain.Features.Blog;
using DotNet8.AuditLogMiniProject.DTOs.Features.Blog;
using DotNet8.AuditLogMiniProject.Extensions;
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

        public BlogService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Result<BlogDTO>> AddBlogAsync(BlogRequestDTO blogRequest, CancellationToken cs)
        {
            Result<BlogDTO> result;
            try
            {
                await _context.Tbl_Blog.AddAsync(blogRequest.ToEntity(), cs);
                await _context.SaveChangesAsync(cs);

                result = Result<BlogDTO>.Success();
            }
            catch (Exception ex)
            {
                result = Result<BlogDTO>.Fail(ex);
            }

        result:
            return result;
        }
    }
}
