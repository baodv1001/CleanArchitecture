using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Interfaces.Responses.Dateoffs
{
    public interface IDateoffGetResponse
    {
        Guid DateoffId { get; set; }
        DateTime OffDate { get; set; }
        string Name { get; set; }
        bool MorningFlg { get; set; }
        bool AfternoonFlg { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
