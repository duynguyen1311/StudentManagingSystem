using StudentManagingSystem.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentManagingSystem.ViewModel
{
    public class ClassRoomViewModel
    {
        public Guid Id { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public bool? Status { get; set; }
        public DepartmentViewModel? Department { get; set; }
        public UserViewModel? User { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        
    }
    public class ClassRoomAddRequest
    {
        public Guid Id { get; set; }
        public string ClassName { get; set; }
        public string ClassCode { get; set; }
        public bool? Status { get; set; }
        [Display(Name = "Department")]
        public Guid? DepartmentId { get; set; }
        [Display(Name = "Teacher")]
        public string? UserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
