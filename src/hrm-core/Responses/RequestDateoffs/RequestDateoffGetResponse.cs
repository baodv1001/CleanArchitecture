using hrm_core.Interfaces.Responses.EmployeeTeams;
using hrm_core.Interfaces.Responses.RequestDateoffs;
using hrm_core.Responses.Dateoffs;
using hrm_core.Responses.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hrm_core.Responses.RequestDateoffs
{
    public class RequestDateoffGetResponse : IRequestDateoffGetResponse
    {
        public DateoffGetResponse Dateoff { get ; set ; }
        public Guid DateoffId { get ; set ; }
    }
}
