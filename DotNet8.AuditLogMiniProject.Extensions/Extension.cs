using DotNet8.AuditLogMiniProject.Domain.Features.Audit;
using DotNet8.AuditLogMiniProject.Domain.Features.Blog;
using DotNet8.AuditLogMiniProject.DTOs.Features.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.AuditLogMiniProject.Extensions
{
    public static class Extension
    {
        public static Tbl_Blog ToEntity(this BlogRequestDTO blogRequest)
        {
            return new Tbl_Blog
            {
                BlogTitle = blogRequest.BlogTitle,
                BlogAuthor = blogRequest.BlogAuthor,
                BlogContent = blogRequest.BlogContent
            };
        }
    }
}
