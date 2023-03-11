using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model.Interface;

namespace StudentManagingSystem.Model
{
    public class SmsDbContext : DbContext, ISmsDbContext
    {
        public SmsDbContext(DbContextOptions<SmsDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //new SeedDataApplicationDatabaseContext(builder).Seed();

            // Rename AspNet default tables
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<UserRole>().ToTable("UserRoles");
            builder.Entity<UserRole>().Ignore(c => c.User);
            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
            
            builder.Entity<Point>()
                .HasKey(p => new { p.SubjectId, p.StudentId });
            builder.Entity<Point>()
                .HasOne(p => p.Subject)
                .WithMany(p => p.Point)
                .HasForeignKey(p => p.SubjectId);
            builder.Entity<Point>()
                .HasOne(p => p.Student)
                .WithMany(p => p.Point)
                .HasForeignKey(p => p.StudentId);

            builder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(e => e.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return (await base.SaveChangesAsync(true, cancellationToken));
        }
    }
}
