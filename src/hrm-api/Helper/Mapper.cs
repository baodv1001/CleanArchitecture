using AutoMapper;
using hrm_core.DomainModels;
using hrm_core.Requests.Employees;
using hrm_core.Responses.Approvers;
using hrm_core.Responses.Dateoffs;
using hrm_core.Responses.Employees;
using hrm_core.Responses.EmployeeTeams;
using hrm_core.Responses.RequestDateoffs;
using hrm_core.Responses.Requests;
using hrm_core.Responses.Teams;
using hrm_core.Responses.Users;
using hrm_infrastructure.Entities;

namespace hrm_api.Helper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<PositionEntity, Position>().ReverseMap();
            CreateMap<EmployeeEntity, Employee>().ReverseMap();
            CreateMap<DepartmentEnity, Department>().ReverseMap();
            CreateMap<EmployeeTypeEntity, EmployeeType>().ReverseMap();
            CreateMap<PersonalEntity, Personal>().ReverseMap();
            CreateMap<OfficeEntity, Office>().ReverseMap();
            CreateMap<TeamEntity, Team>().ReverseMap();

            CreateMap<EmployeeEntity, EmployeeGetResponse>()
                .ForMember(t => t.PositionName, opt => opt.MapFrom(t => t.Position.Name))
                .ForMember(t => t.OfficeName, opt => opt.MapFrom(t => t.Office.Name))
                .ForMember(t => t.FirstName, opt => opt.MapFrom(t => t.Personal.FirstName))
                .ForMember(t => t.LastName, opt => opt.MapFrom(t => t.Personal.LastName))
                .ForMember(t => t.PhoneNumber, opt => opt.MapFrom(t => t.Personal.PhoneNumber))
                .ForMember(t => t.Address, opt => opt.MapFrom(t => t.Personal.Address))
                .ForMember(t => t.Email, opt => opt.MapFrom(t => t.Personal.Email))
                .ForMember(t => t.Dob, opt => opt.MapFrom(t => t.Personal.Dob))
                .ForMember(t => t.Gender, opt => opt.MapFrom(t => t.Personal.Gender))
                .ForMember(t => t.IdentityCard, opt => opt.MapFrom(t => t.Personal.IdentityCard))
                .ForMember(t => t.StartDate, opt => opt.MapFrom(t => t.Personal.StartDate))
                .ForMember(t => t.EmployeeTypeName, opt => opt.MapFrom(t => t.EmployeeType.TypeName))
                .ForMember(t => t.EmployeeTeams, opt => opt.MapFrom(t => t.EmployeeTeams));
            CreateMap<TeamEntity, TeamGetEmployeeResponse>();

            CreateMap<EmployeeTeamEntity, EmployeeTeam>().ReverseMap();
            CreateMap<EmployeeTeamEntity, EmployeeTeamGetEmployeeResponse>();
            CreateMap<TeamEntity, TeamGetEmployeeResponse>();

            CreateMap<EmployeeEntity, EmployeeUpdateRequest>().ReverseMap();
            CreateMap<PersonalEntity, EmployeeUpdateRequest>().ReverseMap();

            CreateMap<UserEntity, User>().ReverseMap();

            CreateMap<User, UserGetResponse>()
                .ForMember(t => t.Role, opt => opt.MapFrom(t => t.Role.RoleNum));
            
            CreateMap<RoleEntity, Role>().ReverseMap();

            CreateMap<RequestEntity, Timeoff>().ReverseMap();

            CreateMap<DateoffEntity, Dateoff>().ReverseMap();

            CreateMap<RequestModelEntity, RequestModel>().ReverseMap();

            CreateMap<ApproverEntity, Approver>().ReverseMap();

            CreateMap<RequestDateoffEntity, RequestDateoff>().ReverseMap();

            CreateMap<RequestEntity, RequestGetResponse>().ReverseMap();
               /* .ForMember(t => t.RequestModelName, opt => opt.MapFrom(t => t.RequestModel.Name))
                .ForMember(t => t.EmployeeName, opt => opt.MapFrom(t => t.Employee.Personal.FirstName + ' ' + t.Employee.Personal.LastName))
                .ForMember(t => t.RequestDateoffs, opt => opt.MapFrom(t => t.RequestDateoffs))
                .ForMember(t => t.Approvers, opt => opt.MapFrom(t => t.RequestModel.Approvers))
                .ForMember(t => t.DistanceDays, opt => opt.MapFrom(t => t.RequestModel.DistanceDays))
                .ForMember(t => t.LimitDays, opt => opt.MapFrom(t => t.RequestModel.LimitDays))
                .ForMember(t => t.Deadline, opt => opt.MapFrom(t => t.RequestModel.Deadline));*/

            CreateMap<ApproverEntity, ApproverGetResponse>()
                .ForMember(t => t.EmployeeId, opt => opt.MapFrom(t => t.EmployeeId))
                .ForMember(t => t.Avatar, opt => opt.MapFrom(t => t.Employee.Avatar))
                .ForMember(t => t.EmployeeEmail, opt => opt.MapFrom(t => t.Employee.User.Email))
                .ForMember(t => t.Name, opt => opt.MapFrom(t => t.Employee.Personal.FirstName + ' ' + t.Employee.Personal.LastName));

            CreateMap<DateoffEntity, DateoffGetResponse>().ReverseMap();
            CreateMap<RequestDateoffEntity, RequestDateoffGetResponse>().ReverseMap();

        }
    }
}
