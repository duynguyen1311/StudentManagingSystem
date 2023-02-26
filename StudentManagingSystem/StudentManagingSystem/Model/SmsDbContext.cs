using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace StudentManagingSystem.Model
{
    public class SmsDbContext : IdentityDbContext
    {
        public SmsDbContext(DbContextOptions<SmsDbContext> options) : base(options)
        {
        }
    }
}
