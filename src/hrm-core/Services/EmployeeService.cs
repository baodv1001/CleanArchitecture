using hrm_core.DomainModels;
using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Requests.Employees;
using hrm_core.Interfaces.Services;
using hrm_core.Parameters;
using hrm_core.Responses.Employees;

namespace hrm_core.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPersonalRepository _personalRepository;
        private readonly IEmployeeTeamRepository _employeeTeamRepository;
        private readonly IUserRepository _userRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IPersonalRepository personalRepository, IEmployeeTeamRepository employeeTeamRepository, IUserRepository userRepository, ICommonRepository commonRepository) : base(commonRepository)
        {
            _employeeRepository = employeeRepository;
            _personalRepository = personalRepository;
            _employeeTeamRepository = employeeTeamRepository;
            _userRepository = userRepository;
        }

        public async Task<EmployeeGetAllResponse> GetAll(EmployeeGetAllParameters employeeParameters)
        { 
            return await _employeeRepository.GetAll(employeeParameters);
        }

        public async Task<Employee> Create(IEmployeeCreateRequest employee, B2CUser user)
        {
            var newPersonal = new Personal()
            {
                PersonalId = Guid.NewGuid(),
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                PhoneNumber = employee.PhoneNumber,
                Address = employee.Address,
                Email = employee.Email,
                Dob = employee.Dob,
                Gender = employee.Gender,
                IdentityCard = employee.IdentityCard,
                StartDate = employee.StartDate,

                CreatedDate = DateTime.Now,
                CreatedBy = "Postman",
            };

            await _personalRepository.Create(newPersonal);

            var crEmployee = new Employee()
            {
                EmployeeId = Guid.NewGuid(),
                Status = employee.Status,
                PersonalId = newPersonal.PersonalId,
                PositionId = employee.PositionId,
                EmployeeTypeId = employee.EmployeeTypeId,
                OfficeId = employee.OfficeId,
                ExtraNote = employee.ExtraNote,

                CreatedDate = DateTime.Now,
                CreatedBy = "Postman",
            };

            crEmployee.Code = await GetNewEmployeeCode(employee.TeamId.Count > 0 ? employee.TeamId[0] : Guid.Empty);

            var rsEmployee = await _employeeRepository.Create(crEmployee);

            foreach (var tId in employee.TeamId)
            {
                var crEmployeeTeam = new EmployeeTeam()
                {
                    EmployeeId = crEmployee.EmployeeId,
                    TeamId = tId
                };
                await _employeeTeamRepository.Create(crEmployeeTeam);
            }

            var newUser = new User()
            {
                UserId = Guid.NewGuid(),
                Email = user.Identities.FirstOrDefault().IssuerAssignedId,
                EmployeeId = rsEmployee.EmployeeId,
                RoleId = await GetBaseRole(),
                Subject = user.Subject
            };

            await _userRepository.Signup(newUser);

            return rsEmployee;
        }

        public async Task<EmployeeGetResponse> GetById(Guid id)
        {
            return await _employeeRepository.GetById(id);
        }

        public async Task<Employee> Update(Guid id, IEmployeeUpdateRequest request)
        {

            var newEmployee = await _employeeRepository.Update(request, id);

            await _personalRepository.Update(request, newEmployee.PersonalId);

            var listOldTeams = await _employeeTeamRepository.GetListTeamByEmpId(id);

            foreach (var team in listOldTeams)
            {
                if (!request.TeamId.Contains(team.TeamId))
                {
                    await _employeeTeamRepository.Delete(team.TeamId, id);
                }
            }

            foreach (var tId in request.TeamId)
            {
                if (await _employeeTeamRepository.ExistEmployeeTeam(tId, id) == false)
                {
                    var crEmployeeTeam = new EmployeeTeam()
                    {
                        EmployeeId = id,
                        TeamId = tId
                    };
                    await _employeeTeamRepository.Create(crEmployeeTeam);
                }
            }

            return newEmployee;
        }

        public async Task<bool> UpdateAvatar(string url, Guid id)
        {
            return await _employeeRepository.UpdateAvatar(url, id);
        }

        public async Task<Employee> Delete(Guid id)
        {
            return await _employeeRepository.Delete(id);
        }
    }
}
