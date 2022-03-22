using hrm_core.Interfaces.Requests.Offices;

namespace hrm_core.Requests.Offices
{
    public class OfficeCreateRequest : IOfficeCreateRequest
    {
        public string Name { get; set; }
        public string Area { get; set; }
    }
}
