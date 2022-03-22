using AutoMapper;
using hrm_core.Enums;
using hrm_core.Interfaces.Repositories;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace hrm_infrastructure.Repositories
{
    public class CommonRepository : ICommonRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommonRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> GetEmployeeNum()
        {
            var dbCode = _dbContext.Codes.FirstOrDefault();
            var employeeNum = dbCode.EmployeeNum;

            dbCode.EmployeeNum += 1;
            await _dbContext.SaveChangesAsync();

            return employeeNum;
        }
        public async Task<string> GetDepartmentPrefix(Guid teamId)
        {
            if (teamId == Guid.Empty)
            {
                return "NO";
            }

            var db = await _dbContext.Teams.Where(t => t.TeamId == teamId).Include(t => t.Department).FirstOrDefaultAsync();

            switch (db.Department.Name)
            {
                case "Developers":
                    {
                        return "DE";
                    }
                case "Human Resources":
                    {
                        return "HR";
                    }
                default: return "GE";
            }
        }
        public async Task<Guid> GetBaseRole()
        {
            var baseRole = await _dbContext.Roles.Where(r => r.RoleNum == (int)RoleType.EMPLOYEE).FirstOrDefaultAsync();
            return baseRole.RoleId;
        }

        public async Task SeedSampleData()
        {
            _dbContext.Offices.AddRange(new[]
            {
                new OfficeEntity() { OfficeId = new Guid("22EDDFD6-41C1-45AD-8768-38058B7BFE06"), Name = "Logixtek", Area = "Ho Chi Minh", CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" },
                new OfficeEntity() { OfficeId = new Guid("9B4A9DDF-D7FD-4CC7-BDFD-E296223F1282"), Name = "Logix Campus", Area = "Da Nang", CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" }
            });

            _dbContext.Departments.AddRange(new[]
            {
                new DepartmentEnity() { DepartmentId = new Guid("012CCDB8-4BB7-4438-BEAF-29E3C2E31DBE"), Name = "Developers", CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" },
                new DepartmentEnity() { DepartmentId = new Guid("D33B2535-8AE0-4CB8-AF0E-622285098BD6"), Name = "Human Resources", CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" }
            });

            _dbContext.Teams.AddRange(new[]
            {
                new TeamEntity() { TeamId = new Guid("BF72099F-EBFE-47EA-A34C-3CA7E9379211"), Name = "CT4", Description = "Team anh Quang dep trai", DepartmentId = new Guid("012CCDB8-4BB7-4438-BEAF-29E3C2E31DBE"), CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" },
                new TeamEntity() { TeamId = new Guid("7D5BA743-D508-4872-9E48-B9C6F4AFEFBA"), Name = "Selhub", Description = "Team pro", DepartmentId = new Guid("012CCDB8-4BB7-4438-BEAF-29E3C2E31DBE"), CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" },
                new TeamEntity() { TeamId = new Guid("85FA443B-2623-40FB-91CF-31D134E83665"), Name = "CVCheck", Description ="Team check CV", DepartmentId = new Guid("D33B2535-8AE0-4CB8-AF0E-622285098BD6"), CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" }
            });

            _dbContext.Positions.AddRange(new[]
            {
                new PositionEntity() { PositionId = new Guid("F7302490-DA7F-438C-8260-0349E7E24912"), Name = "Junior", CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" },
                new PositionEntity() { PositionId = new Guid("09AD085E-80EE-4F3B-83DB-B152BF3682DC"), Name = "Intern", CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" },
                new PositionEntity() { PositionId = new Guid("FFB77982-2675-4BEA-ABCD-C496400B6F2E"), Name = "Senior", CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" }
            });

            _dbContext.EmployeeTypes.AddRange(new[]
            {
                new EmployeeTypeEntity() { EmployeeTypeId = new Guid("BA03F42B-EC34-4A68-86EA-633D176D6D8E"), TypeName = "FrontEnd", CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" },
                new EmployeeTypeEntity() { EmployeeTypeId = new Guid("E8B521B4-406E-47D2-A47B-82A158C26E3C"), TypeName = "FullStack", CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" },
                new EmployeeTypeEntity() { EmployeeTypeId = new Guid("49FBFA20-A477-44F5-8E08-93E3337399F3"), TypeName = "BackEnd", CreatedDate = DateTime.Parse("2022-03-01 14:28:37.0327396"), CreatedBy = "DataSeeder" }
            });
            
            _dbContext.Users.Add(new UserEntity() {UserId= new Guid("9AA8E592-2893-48A6-A50D-1AB8A0A93165"), Email= "vuratngu2001@gmail.com", Subject= "8053a5ac-370d-4b59-957e-59aa57034e01", RoleId= new Guid("C5BD4C5B-D871-445D-B1C9-C10B278DC448") });

            await _dbContext.SaveChangesAsync();
        }
    }
}
