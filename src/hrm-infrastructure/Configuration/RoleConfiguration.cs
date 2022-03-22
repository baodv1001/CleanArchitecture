using hrm_core.Enums;
using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hrm_infrastructure.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable("Roles");

            builder.HasData(
                new RoleEntity() { RoleId = new Guid("C5BD4C5B-D871-445D-B1C9-C10B278DC448"), RoleName = "Admin", RoleNum = (int)RoleType.ADMIN },
                new RoleEntity() { RoleId = new Guid("462FF7F9-B75B-47E8-AFAF-379ECC78CED8"), RoleName = "Leader", RoleNum = (int)RoleType.LEADER },
                new RoleEntity() { RoleId = new Guid("A1242EA5-DA62-417E-B493-BD6AEB67D678"), RoleName = "Human Resource", RoleNum = (int)RoleType.HR },
                new RoleEntity() { RoleId = new Guid("BAD2DAE2-050D-47B5-8549-12644F44ACFF"), RoleName = "Employee", RoleNum = (int)RoleType.EMPLOYEE },
                new RoleEntity() { RoleId = new Guid("96BDCB87-5F30-4121-9E1C-807B38E97AD6"), RoleName = "Guest", RoleNum = (int)RoleType.GUEST });
        }
    }
}
