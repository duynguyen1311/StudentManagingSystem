using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;

namespace StudentManagingSystem.Pages.TeacherPage
{
    [Authorize(Roles = RoleConstant.ADMIN)]
    public class TeacherModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _repository;

        public PagedList<AppUser> ListTeacher { get; set; }
        [BindProperty]
        public string? Keyword { get; set; }
        [BindProperty]
        public bool? Status { get; set; }
        public int PageIndex { get; set; } = 1;
        public int TotalPage { get; set; }
        public TeacherModel(UserManager<AppUser> userManager, IUserRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(string? keyword, bool? status, int pageIndex, int pagesize)
        {
            Keyword = keyword;
            Status = status;
            if (pageIndex == 0) pageIndex = 1;
            PageIndex = pageIndex;
            pagesize = 4;
            ListTeacher = await _repository.Search(keyword, status, pageIndex, pagesize);
            TotalPage = (int)(Math.Ceiling(ListTeacher.TotalCount / (double)pagesize));
            return Page();
        }
    }
}
