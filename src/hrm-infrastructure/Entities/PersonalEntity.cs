using System.ComponentModel.DataAnnotations;

namespace hrm_infrastructure.Entities
{
    public class PersonalEntity : BaseEntity
    {
        [Key]
        [Required]
        public Guid PersonalId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
        public int Gender { get; set; }
        [Required]
        public string IdentityCard { get; set; }
        public DateTime StartDate { get; set; }

        public virtual EmployeeEntity Employee { get; set; }
    }
}
