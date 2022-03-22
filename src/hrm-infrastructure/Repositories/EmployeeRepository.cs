using AutoMapper;
using hrm_core.Enums;
using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Requests.Employees;
using hrm_core.DomainModels;
using hrm_core.Parameters;
using hrm_core.Responses.Employees;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace hrm_infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeGetAllResponse> GetAll(EmployeeGetAllParameters employeeParameters)
        {
            var total = (await _dbContext.Employees
                            .Where(e => e.Status != (int)EmployeeStatuses.Deleted && e.Status == employeeParameters.Status
                                        && (e.Personal.FirstName.Contains(employeeParameters.Name) || (e.Personal.LastName.Contains(employeeParameters.Name))))
                            .ToListAsync()).Count;

            var employees = await _dbContext.Employees
                            .Include(item => item.Personal)
                            .Include(item => item.Position)
                            .Include(item => item.EmployeeType)
                            .Include(item => item.Office)
                            .Include(item => item.EmployeeTeams)
                                .ThenInclude(item => item.Team)
                            .Where(e => e.Status != (int)EmployeeStatuses.Deleted && e.Status == employeeParameters.Status
                                        && (e.Personal.FirstName.Contains(employeeParameters.Name) || (e.Personal.LastName.Contains(employeeParameters.Name))))
                            .Skip(employeeParameters.PageSize * (employeeParameters.PageNumber - 1))
                            .Take(employeeParameters.PageSize)
                            .ToListAsync()
                            .ConfigureAwait(false);

            return new EmployeeGetAllResponse()
            {
                Employees = _mapper.Map<IEnumerable<EmployeeGetResponse>>(employees),
                Total = total
            };
        }

        public async Task<Employee> Create(Employee employee)
        {
            var dbEmployee = _mapper.Map<EmployeeEntity>(employee);
            _dbContext.Employees.Add(dbEmployee);
            await _dbContext.SaveChangesAsync();

            _dbContext.Entry(dbEmployee).Reference(c => c.Personal).Load();
            _dbContext.Entry(dbEmployee).Reference(c => c.Position).Load();
            _dbContext.Entry(dbEmployee).Reference(c => c.EmployeeType).Load();
            _dbContext.Entry(dbEmployee).Reference(c => c.Office).Load();

            return _mapper.Map<Employee>(dbEmployee);
        }

        public async Task<EmployeeGetResponse> GetById(Guid id)
        {
            var employee = await _dbContext.Employees
                            .Where(item => item.EmployeeId == id)
                            .AsNoTracking()
                            .Include(item => item.Personal)
                            .Include(item => item.Position)
                            .Include(item => item.EmployeeType)
                            .Include(item => item.Office)
                            .Include(item => item.EmployeeTeams)
                                .ThenInclude(item => item.Team)
                            .FirstOrDefaultAsync()
                            .ConfigureAwait(false);
            return _mapper.Map<EmployeeGetResponse>(employee);
        }

        public async Task<Employee> Update(IEmployeeUpdateRequest employee, Guid employeeId)
        {
            var dbEmployee = await _dbContext.Employees.FindAsync(employeeId);

            _mapper.Map(employee, dbEmployee);

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Employee>(dbEmployee);
        }

        public async Task<Employee> Find(Guid id)
        {
            var employee = await _dbContext.Employees.Where(e => e.EmployeeId == id).AsNoTracking().FirstOrDefaultAsync();
            return _mapper.Map<Employee>(employee);
        }

        public async Task<bool> UpdateAvatar(string url, Guid id)
        {
            var dbEmployee = await _dbContext.Employees.FindAsync(id);

            dbEmployee.Avatar = url;

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Employee> Delete(Guid id)
        {
            var dbEmployee = await _dbContext.Employees.FindAsync(id);

            dbEmployee.Status = (int)EmployeeStatuses.Deleted;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Employee>(dbEmployee);
        }
    }
}