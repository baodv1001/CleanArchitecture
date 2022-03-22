using hrm_core.Interfaces.Responses.Dateoffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Responses.Dateoffs
{
    public class DateoffGetResponse : IDateoffGetResponse
    {
        public Guid DateoffId { get; set; }
        public DateTime OffDate { get; set; }
        public string Name { get; set; }
        public bool MorningFlg { get; set; }
        public bool AfternoonFlg { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
