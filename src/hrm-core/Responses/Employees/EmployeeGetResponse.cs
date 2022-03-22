using hrm_core.Interfaces.Responses.Employees;
using hrm_core.Responses.EmployeeTeams;


namespace hrm_core.Responses.Employees
{
    public class EmployeeGetResponse : IEmployeeGetResponse
    {
        public Guid EmployeeId { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public string ExtraNote { get; set; }
        public string Avatar { get; set; }
        public Guid PositionId { get; set; }
        public string PositionName { get; set; }
        public Guid OfficeId { get; set; }
        public string OfficeName { get; set; }
        public Guid PersonalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public int Gender { get; set; }
        public string IdentityCard { get; set; }
        public DateTime StartDate { get; set; }
        public Guid EmployeeTypeId { get; set; }
        public string EmployeeTypeName { get; set; }
        public ICollection<EmployeeTeamGetEmployeeResponse> EmployeeTeams { get; set; }
    }
}
