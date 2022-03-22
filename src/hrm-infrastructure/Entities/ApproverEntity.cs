using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_infrastructure.Entities
{
    public class ApproverEntity : BaseEntity
    {
        [Key]
        public Guid EmployeeId { get; set; }
        public virtual EmployeeEntity Employee { get; set; }
        [Key]
        public Guid RequestModelId { get; set; }
        public virtual RequestModelEntity RequestModel { get; set; }
    }
}
