namespace hrm_core.Interfaces.Requests.Employees
{
    public interface IEmployeeCreateRequest
    {
        Guid PositionId { get; set; }
        Guid OfficeId { get; set; }
        Guid EmployeeTypeId { get; set; }
        int Status { get; set; }
        string ExtraNote { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string Email { get; set; }
        DateTime Dob { get; set; }
        int Gender { get; set; }
        string IdentityCard { get; set; }
        DateTime StartDate { get; set; }
        List<Guid> TeamId { get; set; }
    }
}