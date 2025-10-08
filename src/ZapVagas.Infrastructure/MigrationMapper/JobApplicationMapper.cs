using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZapVagas.Domain.Entities;

namespace ZapVagas.Infrastructure.MigrationMapper
{
    public class JobApplicationMapper : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.ToTable("JobApplications");

            builder.HasKey(ja => ja.ApplicationId);
            builder.Property(ja => ja.ApplicationId).ValueGeneratedOnAdd();

            builder.Property(ja => ja.ApplicationDate).IsRequired();

            builder.HasOne(ja => ja.Candidate)
                   .WithMany(c => c.JobApplications)
                   .HasForeignKey(ja => ja.CandidateId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ja => ja.Vacancy)
                     .WithMany(v => v.JobApplications)
                     .HasForeignKey(ja => ja.VacancyId)
                     .OnDelete(DeleteBehavior.Cascade);

            builder.Property(v => v.Status)
                .IsRequired()
                .HasConversion<string>();
        }
    }
}
