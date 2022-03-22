using System.ComponentModel.DataAnnotations;

namespace hrm_infrastructure.Entities
{
    public class EmployeeEntity : BaseEntity
    {
        [Key]
        [Required]
        public Guid EmployeeId { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public int Status { get; set; }

        public string ExtraNote { get; set; }
        public string Avatar { get; set; }
        public Guid? PositionId { get; set; }
        public virtual PositionEntity Position { get; set; }

        public Guid? OfficeId { get; set; }
        public virtual OfficeEntity Office { get; set; }

        public Guid? PersonalId { get; set; }
        public virtual PersonalEntity Personal { get; set; }

        public Guid? EmployeeTypeId { get; set; }
        public virtual EmployeeTypeEntity EmployeeType { get; set; }

        public virtual ICollection<EmployeeTeamEntity> EmployeeTeams { get; set; }

        public virtual ICollection<TeamEntity> TeamLeaders { get; set; }
        public virtual ICollection<RequestEntity> Requests { get; set; }
        public virtual ICollection<ApproverEntity> Approvers { get; set; }
        public virtual UserEntity User { get; set; }

    }
}
