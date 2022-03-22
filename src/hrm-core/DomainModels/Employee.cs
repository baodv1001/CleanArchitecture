using System.Text.Json.Serialization;

namespace hrm_core.DomainModels
{
    public class Employee : BaseModel
    {
        public Guid EmployeeId { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public string ExtraNote { get; set; }
        public string Avatar { get; set; }
        [JsonIgnore]
        public Guid PositionId { get; set; }
        public virtual Position Position { get; set; }
        [JsonIgnore]
        public Guid OfficeId { get; set; }
        public Office Office { get; set; }
        public Guid? PersonalId { get; set; }
        public virtual Personal Personal { get; set; }
        [JsonIgnore]
        public Guid EmployeeTypeId { get; set; }
        public virtual EmployeeType EmployeeType { get; set; }
        public virtual ICollection<EmployeeTeam> EmployeeTeams { get; set; }
        public virtual ICollection<Team> TeamLeaders { get; set; }
    }
}
