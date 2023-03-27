using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;

namespace StudentManagingSystem.Pages.PointPage
{
    public class PointModel : PageModel
    {
        private readonly IPointRepository _repository;
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;

        public PagedList<Point> ListPoint { get; set; }
        public List<Student> ListStudent { get; set; }
        public List<Subject> ListSubject { get; set; }
        [BindProperty]
        public string? Keyword { get; set; }
        [BindProperty]
        public string? SubjectId { get; set; }
        [BindProperty]
        public string? StudentId { get; set; }
        public int PageIndex { get; set; } = 1;
        public int TotalPage { get; set; }
        public PointModel(IPointRepository repository, IStudentRepository studentRepository, ISubjectRepository subjectRepository)
        {
            _repository = repository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
        }
        public async Task<IActionResult> OnGetAsync(string? keyword, Guid? stuId, Guid? subId, int pageIndex, int pagesize)
        {
            ListStudent = await _studentRepository.GetAllWithoutFilter();
            ListSubject = await _subjectRepository.GetAll();
            Keyword = keyword;
            StudentId = stuId.ToString();
            SubjectId = subId.ToString();
            if (pageIndex == 0) pageIndex = 1;
            PageIndex = pageIndex;
            pagesize = 4;
            ListPoint = await _repository.Search(keyword, subId, stuId, pageIndex, pagesize);
            TotalPage = (int)(Math.Ceiling(ListPoint.TotalCount / (double)pagesize));
            return Page();
        }
    }
}
