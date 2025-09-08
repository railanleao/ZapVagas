using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZapVagas.Domain.Entities;

namespace ZapVagas.Infrastructure.MigrationMapper
{
    internal class CandidateMapper : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidates");
            //setup PK
            builder.HasKey(c => c.CandidateId);
            builder.Property(c => c.CandidateId).ValueGeneratedNever();

            //Dates
            builder.Property(c => c.StartDate).IsRequired();

            builder.Property(c => c.Name).HasMaxLength(150).IsRequired();
            builder.Property(c => c.Phone).HasMaxLength(20).IsRequired();
            builder.Property(c => c.Education).HasMaxLength(50).IsRequired(false);
        }
    }
}
