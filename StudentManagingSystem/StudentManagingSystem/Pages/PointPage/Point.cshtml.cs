using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;

namespace StudentManagingSystem.Pages.PointPage
{
    [Authorize]
    public class PointModel : PageModel
    {
        private readonly IPointRepository _repository;
        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly UserManager<AppUser> _userManager;

        public PagedList<Point> ListPoint { get; set; }
        public List<Student> ListStudent { get; set; }
        public List<Subject> ListSubject { get; set; }
        [BindProperty]
        public string? Keyword { get; set; }
        [BindProperty]
        public int? Semester { get; set; }
        public int PageIndex { get; set; } = 1;
        public int TotalPage { get; set; }
        public PointModel(IPointRepository repository, IStudentRepository studentRepository, ISubjectRepository subjectRepository, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync(int? semester,string? keyword, Guid? stuId, Guid? subId, int pageIndex, int pagesize)
        {
            var user = await _userManager.GetUserAsync(User);
            var role = await _userManager.GetRolesAsync(user);
            if (role.Contains(RoleConstant.STUDENT))
            {
                var st = await _studentRepository.GetById(Guid.Parse(user.Id));
                Semester = semester;
                Keyword = keyword;
                if (pageIndex == 0) pageIndex = 1;
                PageIndex = pageIndex;
                pagesize = 4;
                ListPoint = await _repository.Search(keyword, semester ?? st.InSemester, subId, st.Id, pageIndex, pagesize);
                TotalPage = (int)(Math.Ceiling(ListPoint.TotalCount / (double)pagesize));
            }
            else
            {
                ListStudent = await _studentRepository.GetAllWithoutFilter();
                ListSubject = await _subjectRepository.GetAll();
                Keyword = keyword;
                if (pageIndex == 0) pageIndex = 1;
                PageIndex = pageIndex;
                pagesize = 4;
                ListPoint = await _repository.Search(keyword, semester, subId, stuId, pageIndex, pagesize);
                TotalPage = (int)(Math.Ceiling(ListPoint.TotalCount / (double)pagesize));
            }

            return Page();
        }
    }
}
