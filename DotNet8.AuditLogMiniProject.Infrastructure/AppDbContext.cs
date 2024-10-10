using DotNet8.AuditLogMiniProject.Domain.Features.Audit;
using DotNet8.AuditLogMiniProject.Domain.Features.Blog;
using DotNet8.AuditLogMiniProject.Infrastructure.Interceptors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.AuditLogMiniProject.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tbl_Blog> Tbl_Blog { get; set; }
        public DbSet<Tbl_Audit> Tbl_Audit { get; set; }
    }
}
