using hrm_api.Authorization;
using hrm_core.Interfaces.Repositories;
using hrm_core.Interfaces.Services;
using hrm_core.DomainModels;
using hrm_core.Services;
using hrm_infrastructure.Context;
using hrm_infrastructure.ExternalServices;
using hrm_infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace hrm_api
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            var dbConnectionString = configuration.GetConnectionString("HRMDbContext");

            services.AddDbContext<HRMDbContext>(
                optionsAction: options => options.UseSqlServer(dbConnectionString),
                contextLifetime: ServiceLifetime.Scoped,
                optionsLifetime: ServiceLifetime.Scoped);
            var a = configuration.GetValue<MailSettings>("MailSettings");
            services.Configure<MailSettings>(opts => configuration.GetSection("MailSettings").Bind(opts));

            services.AddTransient<ISendMailService, SendMailService>();

            services.AddScoped<ICommonRepository, CommonRepository>();

            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IPositionService, PositionService>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            services.AddScoped<IPersonalRepository, PersonalRepository>();
            services.AddScoped<IPersonalService, PersonalService>();

            services.AddScoped<IEmployeeTypeRepository, EmployeeTypeRepository>();
            services.AddScoped<IEmployeeTypeService, EmployeeTypeService>();

            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IOfficeService, OfficeService>();

            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<ITeamService, TeamService>();

            services.AddScoped<IEmployeeTeamRepository, EmployeeTeamRepository>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IAuthorizationHandler, AdminAuthorizationHandler>();
            services.AddScoped<IAuthorizationMiddlewareResultHandler, AuthorizationResultTransformer>();

            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IFileService, FileService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITimeoffRepository, TimeoffRepository>();
            services.AddScoped<ITimeoffService, TimeoffService>();

            services.AddScoped<IDateoffRepository, DateoffRepository>();

            services.AddScoped<IRequestDateoffRepository, RequestDateoffRepository>();

            services.AddScoped<IAdminService, AdminService>();

            return services;
        }
    }
}
