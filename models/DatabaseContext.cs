using Microsoft.EntityFrameworkCore;

namespace Auth.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Patient>? Patients { get; set; }
        public virtual DbSet<UserInfo>? UserInfos { get; set; } 
        public List<UserInfo> getUsers() => UserInfos!.ToList();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInfo>(entity =>
            {
                // entity.HasNoKey();
                entity.ToTable("UserInfo");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.DisplayName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(64).IsUnicode(false);
                entity.Property(e => e.CreatedDate).IsUnicode(false);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                // entity.HasNoKey();
                entity.ToTable("Patient");
                entity.Property(e => e.PatientId).HasColumnName("PatientId");
                entity.Property(e => e.PatientName).HasMaxLength(100).IsUnicode(false);
                entity.Property(e => e.LoginID).HasMaxLength(256).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
