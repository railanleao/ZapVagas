using Microsoft.EntityFrameworkCore;
using ZapVagas.Domain.Entities;

namespace ZapVagas.Infrastructure.DataContext
{
    public class ZapVagasDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobPreference> JobPreferences { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<JobVacancy> JobVacancies { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source= Banco.ZapVagas");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ZapVagasDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
