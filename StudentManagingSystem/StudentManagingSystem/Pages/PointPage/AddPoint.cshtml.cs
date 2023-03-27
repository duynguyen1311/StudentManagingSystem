using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using StudentManagingSystem.ViewModel;
using System.Data;

namespace StudentManagingSystem.Pages.PointPage
{
    [Authorize(Roles = RoleConstant.ADMIN)]
    public class AddPointModel : PageModel
    {
        private readonly IPointRepository _repository;
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        [BindProperty]
        public PointAddRequest PointAddRequest { get; set; }
        public List<Student> ListStudent { get; set; }
        public List<Subject> ListSubject { get; set; }
        public AddPointModel(IPointRepository repository, IStudentRepository studentRepository, ISubjectRepository subjectRepository, IMapper mapper)
        {
            _repository = repository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            ListStudent = await _studentRepository.GetAllWithoutFilter();
            ListSubject = await _subjectRepository.GetAll();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            var dept = _mapper.Map<Point>(PointAddRequest);
            dept.Id = Guid.NewGuid();
            dept.CreatedDate = DateTime.Now;
            dept.LastModifiedDate = null;
            await _repository.Add(dept);

            return RedirectToPage("/PointPage/Point");
        }
    }
}
