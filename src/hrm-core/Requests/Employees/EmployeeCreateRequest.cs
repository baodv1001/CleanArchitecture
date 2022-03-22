using hrm_core.Interfaces.Requests.Employees;

namespace hrm_core.Requests.Employees
{
    public class EmployeeCreateRequest : IEmployeeCreateRequest
    {
        public Guid PositionId { get; set; }
        public Guid OfficeId { get; set; }
        public Guid EmployeeTypeId { get; set; }
        public int Status { get; set; }
        public string ExtraNote { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public int Gender { get; set; }
        public string IdentityCard { get; set; }
        public DateTime StartDate { get; set; }
        public List<Guid> TeamId { get; set; }
    }
}
