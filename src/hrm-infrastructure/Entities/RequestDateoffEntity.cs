using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_infrastructure.Entities
{
    public class RequestDateoffEntity
    {
        [Key]
        public Guid RequestId { get; set; }
        public virtual RequestEntity Request { get; set; }
        [Key]
        public Guid DateoffId { get; set; }
        public virtual DateoffEntity Dateoff { get; set; }
    }
}
