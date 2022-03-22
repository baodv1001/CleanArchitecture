using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_infrastructure.Entities
{
    public class RequestEntity : BaseEntity
    {
        [Key]
        [Required]
        public Guid RequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string[] Attachments { get ; set; } 
        public Guid? RequestModelId { get; set; }
        public virtual RequestModelEntity RequestModel { get; set; }
        public Guid? EmployeeId { get; set; }
        public virtual EmployeeEntity Employee { get; set; }
        public virtual ICollection<RequestDateoffEntity> RequestDateoffs { get; set; }
    }
}
