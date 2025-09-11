using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZapVagas.Domain.Entities;

namespace ZapVagas.Infrastructure.MigrationMapper
{
    public class JobPreferenceMapper : IEntityTypeConfiguration<JobPreference>
    {
        public void Configure(EntityTypeBuilder<JobPreference> builder)
        {
            builder.ToTable("JobPreferences");

            //setup PK
            builder.HasKey(jp => jp.PreferenceId);
            builder.Property(jp => jp.PreferenceId).ValueGeneratedNever();

            builder.Property(jp => jp.Area).HasMaxLength(100).IsRequired();
            builder.Property(jp => jp.Location).HasMaxLength(100).IsRequired();


            builder.HasOne(jp => jp.Candidate)             // JobPreference tem um Candidate
               .WithMany(c => c.JobPreferences)            // Candidate tem muitas JobPreferences
               .HasForeignKey(jp => jp.CandidateId)        // FK configurada
               .OnDelete(DeleteBehavior.Cascade);          // Se apagar Candidate, apaga JobPreferences
        }
    }
}
