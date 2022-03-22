using hrm_core.Enums;
using hrm_infrastructure.Configuration;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace hrm_infrastructure.Context
{
    public class HRMDbContext : DbContext
    {

        public HRMDbContext(DbContextOptions<HRMDbContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            SetKey(modelBuilder);
            ConfigDataType(modelBuilder);
            SeedData(modelBuilder);
        }

        protected void SetKey(ModelBuilder modelBuilder)
        {
            //One Office have many Employees
            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(e => e.Office)
                .WithMany(o => o.Employees)
                .HasForeignKey(e => e.OfficeId);

            //One Position have many Employees
            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(e => e.Position)
                .WithMany(p => p.Employees)
                .HasForeignKey(e => e.PositionId);

            //One Personal belong to one Employee
            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(e => e.Personal)
                .WithOne(p => p.Employee)
                .HasForeignKey<EmployeeEntity>(e => e.PersonalId);

            //One EmployeeType have many Employees
            modelBuilder.Entity<EmployeeEntity>()
                .HasOne(e => e.EmployeeType)
                .WithMany(et => et.Employees)
                .HasForeignKey(e => e.EmployeeTypeId);

            //One Employee manager many Teams
            modelBuilder.Entity<TeamEntity>()
                .HasOne(t => t.Manager)
                .WithMany(e => e.TeamLeaders)
                .HasForeignKey(t => t.ManagerId);

            //Many Employees belong to many Teams
            modelBuilder.Entity<EmployeeTeamEntity>()
                .HasKey(et => new { et.EmployeeId, et.TeamId });

            modelBuilder.Entity<EmployeeTeamEntity>()
                .HasOne(et => et.Employee)
                .WithMany(e => e.EmployeeTeams)
                .HasForeignKey(et => et.EmployeeId);

            modelBuilder.Entity<EmployeeTeamEntity>()
                .HasOne(et => et.Team)
                .WithMany(t => t.EmployeeTeams)
                .HasForeignKey(et => et.TeamId);

            //One Department manager many Teams
            modelBuilder.Entity<TeamEntity>()
                .HasOne(t => t.Department)
                .WithMany(d => d.Teams)
                .HasForeignKey(t => t.DepartmentId);

            //One Role have many Users
            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);

            //One User is one Employee
            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.Employee)
                .WithOne(e => e.User)
                .HasForeignKey<UserEntity>(u => u.EmployeeId);

            //One Employee has many Requests
            modelBuilder.Entity<EmployeeEntity>()
                .HasMany(e => e.Requests)
                .WithOne(p => p.Employee)
                .HasForeignKey(e => e.EmployeeId);

            //One RequestModel has many Requests
            modelBuilder.Entity<RequestModelEntity>()
                .HasMany(e => e.Requests)
                .WithOne(p => p.RequestModel)
                .HasForeignKey(e => e.RequestModelId);

            //Many Employees belong to many RequestModel
            modelBuilder.Entity<ApproverEntity>()
                .HasKey(et => new { et.EmployeeId, et.RequestModelId });

            //Many Request belong to many Dateoffs
            modelBuilder.Entity<RequestDateoffEntity>()
                .HasKey(et => new { et.RequestId, et.DateoffId });
        }

        protected void ConfigDataType(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestEntity>()
                .Property(p => p.Attachments)
                .HasConversion(v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<string[]>(v));
        }

        protected void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new CodeConfiguration());
        }


        public virtual DbSet<PositionEntity> Positions { get; set; }
        public virtual DbSet<EmployeeEntity> Employees { get; set; }
        public virtual DbSet<DepartmentEnity> Departments { get; set; }
        public virtual DbSet<EmployeeTypeEntity> EmployeeTypes { get; set; }
        public virtual DbSet<PersonalEntity> Personals { get; set; }
        public virtual DbSet<OfficeEntity> Offices { get; set; }
        public virtual DbSet<TeamEntity> Teams { get; set; }
        public virtual DbSet<EmployeeTeamEntity> EmployeeTeams { get; set; }
        public virtual DbSet<UserEntity> Users { get; set; }
        public virtual DbSet<RoleEntity> Roles { get; set; }
        public virtual DbSet<CodeEntity> Codes { get; set; }
        public virtual DbSet<RequestEntity> Requests { get; set; }
        public virtual DbSet<RequestModelEntity> RequestModels { get; set; }
        public virtual DbSet<ApproverEntity> Approvers { get; set; }
        public virtual DbSet<DateoffEntity> Dateoffs { get; set; }
        public virtual DbSet<RequestDateoffEntity> RequestDateoffs { get; set; }
    }
}

