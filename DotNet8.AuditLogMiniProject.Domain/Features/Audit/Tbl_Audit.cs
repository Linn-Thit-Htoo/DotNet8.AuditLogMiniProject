using System.ComponentModel.DataAnnotations;

namespace DotNet8.AuditLogMiniProject.Domain.Features.Audit
{
    public class Tbl_Audit
    {
        [Key]
        public int AuditId { get; set; }
        public int? Id { get; set; }
        public string EntityName { get; set; }
        public string Operation { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
