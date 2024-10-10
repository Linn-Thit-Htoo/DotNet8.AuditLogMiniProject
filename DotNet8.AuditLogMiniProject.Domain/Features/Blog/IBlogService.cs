using DotNet8.AuditLogMiniProject.DTOs.Features.Blog;
using DotNet8.AuditLogMiniProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.AuditLogMiniProject.Domain.Features.Blog
{
    public interface IBlogService
    {
        Task<Result<BlogDTO>> AddBlogAsync(BlogRequestDTO blogRequest, CancellationToken cs);
        Task<Result<BlogDTO>> UpdateBlogAsync(BlogRequestDTO blogRequest, int id, CancellationToken cs);
    }
}
