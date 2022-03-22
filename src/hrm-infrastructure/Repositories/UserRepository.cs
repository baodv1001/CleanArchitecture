using AutoMapper;
using hrm_core.Enums;
using hrm_core.Interfaces.Repositories;
using hrm_core.DomainModels;
using hrm_infrastructure.Context;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace hrm_infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HRMDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(HRMDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public RoleType GetRole(string subject)
        {
            if (subject == null) return RoleType.GUEST;

            var user = _dbContext.Users.Where(u => u.Subject == subject).Include(item => item.Role).FirstOrDefault();

            if (user == null)
                return RoleType.GUEST;

            return (RoleType)user.Role.RoleNum;
        }

        public async Task<User> Signup(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);
            _dbContext.Users.Add(userEntity);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<User>(userEntity);
        }

        public async Task<User> GetUser(string subject)
        {
            var dbUser = await _dbContext.Users.Where( u=> u.Subject == subject).Include(item => item.Role).FirstOrDefaultAsync();

            if (dbUser == null)
                return null;

            return _mapper.Map<User>(dbUser);
        }
    }
}
