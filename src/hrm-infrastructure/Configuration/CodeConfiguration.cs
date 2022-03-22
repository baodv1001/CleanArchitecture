using hrm_infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hrm_infrastructure.Configuration
{
    public class CodeConfiguration : IEntityTypeConfiguration<CodeEntity>
    {
        public void Configure(EntityTypeBuilder<CodeEntity> builder)
        {
            builder.ToTable("Code");

            builder.HasData(
                new CodeEntity() { CodeId = new Guid("E7F9AEA0-99FD-4E2B-9FF7-66E88E5ACCFB"), EmployeeNum = 1 });

        }
    }
}
