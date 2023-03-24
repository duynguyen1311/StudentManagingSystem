using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagingSystem.ViewModel
{
    public class TeacherViewModel
    {

    }
    public class TeacherAddRequest
    {
        [Required] public string Id { get; set; }
        [Required] public string FullName { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public int Type { get; set; }
        public bool Activated { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
    public class TeacherUpdateRequest
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Adress { get; set; }
        public string? Phone { get; set; }
        public int Type { get; set; }
        public bool Activated { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
    
}
