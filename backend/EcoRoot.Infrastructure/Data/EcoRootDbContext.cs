using EcoRoot.Domain.Entitites;
using Microsoft.EntityFrameworkCore;

namespace EcoRoot.Infrastructure.Data
{
    public class EcoRootDbContext : DbContext
    {
        public EcoRootDbContext(DbContextOptions<EcoRootDbContext> options) : base(options) { }

        public DbSet<Plot> Plots { get; set; }
        public DbSet<Crop> Crops { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<ActivityLog> ActivityLogs { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Crop>()
                .HasOne(c => c.Plot)
                .WithMany(p => p.Crops)
                .HasForeignKey(c => c.PlotId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ActivityLog>()
                .HasOne(a => a.Crop)
                .WithMany(c => c.ActivityLogs)
                .HasForeignKey(a => a.CropId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ActivityLog>()
                .HasOne(a => a.Student)
                .WithMany(s => s.ActivityLogs)
                .HasForeignKey(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Plot>()
                .Property(p => p.Area)
                .HasPrecision(10, 2);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
