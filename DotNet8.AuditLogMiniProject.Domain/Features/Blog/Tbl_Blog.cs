namespace DotNet8.AuditLogMiniProject.Domain.Features.Blog;

public class Tbl_Blog
{
    [Key]
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
}
