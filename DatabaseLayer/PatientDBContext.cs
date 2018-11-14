using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class PatientDBContext : DbContext
    {
        public PatientDBContext()
        { }

        public PatientDBContext(DbContextOptions<PatientDBContext> options) : base(options)
        { }

        public virtual DbSet<Patient> Patient { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=HIBAWL69556;Database=Library_Dev;User Id=sa;Password=Navneet@10");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(e => e.PatientDetails).HasColumnType("xml");
            });
        }

    }
}
