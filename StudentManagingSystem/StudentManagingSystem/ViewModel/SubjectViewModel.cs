using System.ComponentModel.DataAnnotations;

namespace StudentManagingSystem.ViewModel
{
    public class SubjectViewModel
    {
        public Guid Id { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public bool? Status { get; set; }
        public string? Description { get; set; }
        public int? Semester { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
