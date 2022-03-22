using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_infrastructure.Entities
{
    public class RequestModelEntity : BaseEntity
    {
        [Key]
        [Required]
        public Guid RequestModelId { get; set; }
        public string Name { get; set; }
        public bool IsSendDirect { get; set; }
        public int Deadline { get; set; }
        public int DistanceDays { get; set; }
        public int LimitDays { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ApproverEntity> Approvers { get; set; }
        public virtual ICollection<RequestEntity> Requests { get; set; }
    }
}
