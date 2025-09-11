using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZapVagas.Domain.Entities;

namespace ZapVagas.Infrastructure.MigrationMapper
{
    public class CampanyMapper : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies");
            //setup PK
            builder.HasKey(c => c.CompanyId);
            builder.Property(c => c.CompanyId).ValueGeneratedNever();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(200);
            builder.Property(c => c.Cnpj).IsRequired().HasMaxLength(14);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Phone).IsRequired().HasMaxLength(20);
            builder.Property(c => c.StartDate).IsRequired();

        }
    }
}
