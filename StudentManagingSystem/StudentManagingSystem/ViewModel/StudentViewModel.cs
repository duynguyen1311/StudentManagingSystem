using System.ComponentModel.DataAnnotations;

namespace StudentManagingSystem.ViewModel
{
    public class StudentViewModel
    {
        public Guid Id { get; set; }
        public string StudentName { get; set; }
        public string StudentCode { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? Phone { get; set; }
        public bool? Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
