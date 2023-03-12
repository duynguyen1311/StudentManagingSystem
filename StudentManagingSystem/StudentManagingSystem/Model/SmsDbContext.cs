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
        public DbSet<User> Users { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //new SeedDataApplicationDatabaseContext(builder).Seed();

            // Rename AspNet default tables
            builder.Entity<User>().ToTable("Users");
            builder.Entity<Role>().ToTable("Roles");
            
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
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return (await base.SaveChangesAsync(true, cancellationToken));
        }
    }
}
