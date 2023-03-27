using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace StudentManagingSystem.Pages.SubjectPage
{
    public class SubjectModel : PageModel
    {
        private readonly ISubjectRepository _repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IStudentRepository _studentRepository;

        public PagedList<Subject> ListSubject { get; set; }
        [BindProperty]
        public string? Keyword { get; set; }
        [BindProperty]
        public int? Semester { get; set; }
        [BindProperty]
        public bool? Status { get; set; }
        public int PageIndex { get; set; } = 1;
        public int TotalPage { get; set; }
        public SubjectModel(ISubjectRepository repository,IStudentRepository studentRepository, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
            _studentRepository = studentRepository;
        }
        public async Task<IActionResult> OnGetAsync(string? keyword, bool? status,int? semester, int pageIndex, int pagesize)
        {
            var user = await _userManager.GetUserAsync(User);
            var role = await _userManager.GetRolesAsync(user);
            if (role.Contains(RoleConstant.STUDENT))
            {
                var st = await _studentRepository.GetById(Guid.Parse(user.Id));
                Keyword = keyword;
                Status = status;
                Semester = semester;
                if (pageIndex == 0) pageIndex = 1;
                PageIndex = pageIndex;
                pagesize = 4;
                ListSubject = await _repository.SearchByStudent(keyword, status, st.Id,semester ?? st.InSemester, pageIndex, pagesize);
                TotalPage = (int)(Math.Ceiling(ListSubject.TotalCount / (double)pagesize));
            }
            else
            {
                Keyword = keyword;
                Status = status;
                if (pageIndex == 0) pageIndex = 1;
                PageIndex = pageIndex;
                pagesize = 4;
                ListSubject = await _repository.Search(keyword, status, pageIndex, pagesize);
                TotalPage = (int)(Math.Ceiling(ListSubject.TotalCount / (double)pagesize));
            }
            
            return Page();
        }
    }
}
