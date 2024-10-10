using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.AuditLogMiniProject.Domain.Features.Audit
{
    public class Tbl_Audit
    {
        [Key]
        public int AuditId { get; set; }
        public string EntityName { get; set; }
        public string Operation { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
