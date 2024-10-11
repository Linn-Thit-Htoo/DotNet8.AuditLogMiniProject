namespace DotNet8.AuditLogMiniProject.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Tbl_Blog> Tbl_Blog { get; set; }
    public DbSet<Tbl_Audit> Tbl_Audit { get; set; }
}
