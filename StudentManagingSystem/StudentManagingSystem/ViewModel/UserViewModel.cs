using System.ComponentModel.DataAnnotations;

namespace StudentManagingSystem.ViewModel
{
    public class UserViewModel
    {
        public string FullName { get; set; }
    }
    public class UserProfileViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string StudentCode { get; set; }
        public string? Adress { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? Phone { get; set; }
    }
}
