using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_infrastructure.Entities
{
    public class DateoffEntity : BaseEntity
    {
        [Key]
        [Required]
        public Guid DateoffId { get; set; }
        public DateTime OffDate { get; set; }
        public string Name { get; set; }
        public bool MorningFlg { get; set; }
        public bool AfternoonFlg { get; set; }
        public virtual ICollection<RequestDateoffEntity> RequestDateoffs { get; set; }
    }
}
