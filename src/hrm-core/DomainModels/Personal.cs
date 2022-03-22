namespace hrm_core.DomainModels
{
    public class Personal : BaseModel
    {
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

        public virtual Employee Employee { get; set; }
    }
}
