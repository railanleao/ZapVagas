using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZapVagas.Domain.Entities;

namespace ZapVagas.Infrastructure.MigrationMapper
{
    public class JobVacancyMapper : IEntityTypeConfiguration<JobVacancy>
    {
        public void Configure(EntityTypeBuilder<JobVacancy> builder)
        {
            builder.ToTable("JobVacancies");
            //setup PK
            builder.HasKey(v => v.VacancyId);
            builder.Property(v => v.VacancyId).ValueGeneratedNever();
            builder.Property(v => v.CompanyId).IsRequired();

            builder.Property(v => v.Title).IsRequired().HasMaxLength(200);
            builder.Property(v => v.Requirement).IsRequired().HasMaxLength(1000);
            builder.Property(v => v.EducationLevel).IsRequired().HasMaxLength(100);
            builder.Property(v => v.OpenPosition).IsRequired().HasMaxLength(100);
            builder.Property(v => v.Status).IsRequired();
            builder.Property(v => v.StartDate).IsRequired();
            builder.Property(v => v.EndDate).IsRequired(false);

            builder.HasOne(v => v.Company)               // Vacancy tem um Company
               .WithMany(c => c.Vacancies)               // Company tem muitas Vacancies
               .HasForeignKey(v => v.CompanyId)         // FK configurada
               .OnDelete(DeleteBehavior.Cascade);       // Se apagar Company, apaga Vacancies
        }
    }
}
