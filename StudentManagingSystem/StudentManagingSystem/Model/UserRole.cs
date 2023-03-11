using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagingSystem.Model
{
    public class UserRole
    {
        public string UserId { get; set; }

        //[ForeignKey(nameof(UserId))]
        [Column("UserId")]
        public User User { get; set; }

        public string RoleId { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
    }
}
