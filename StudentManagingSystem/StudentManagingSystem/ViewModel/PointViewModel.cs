using StudentManagingSystem.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace StudentManagingSystem.ViewModel
{
    public class PointViewModel
    {
    }
    public class PointAddRequest
    {
        public Guid Id { get; set; }
        [Display(Name = "Student")]
        public Guid StudentId { get; set; }
        [Display(Name = "Subject")]
        public Guid SubjectId { get; set; }
        public float? ProgessPoint { get; set; }
        public float? MidtermPoint { get; set; }
        public float? FinalPoint { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
