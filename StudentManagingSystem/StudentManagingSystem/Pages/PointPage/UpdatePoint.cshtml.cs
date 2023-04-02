using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using System.Data;

namespace StudentManagingSystem.Pages.PointPage
{
    [Authorize]
    public class UpdatePointModel : PageModel
    {
        private readonly IPointRepository _repository;
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;

        public List<Student> ListStudent { get; set; }
        public List<Subject> ListSubject { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        
        [BindProperty]
        public Point Point { get; set; }
        public UpdatePointModel(IPointRepository repository, IStudentRepository studentRepository, ISubjectRepository subjectRepository)
        {
            _repository = repository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            ListStudent = await _studentRepository.GetAllWithoutFilter();
            ListSubject = await _subjectRepository.GetAll();
            Point = await _repository.GetById(id);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Point.LastModifiedDate = DateTime.Now;
            await _repository.Update(Point);
            return RedirectToPage("/PointPage/Point", new { pageIndex = PageIndex });
        }

    }
}
