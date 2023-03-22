using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Pages.TeacherPage
{
    public class TeacherModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _repository;

        public List<AppUser> ListTeacher { get; set; }
        public TeacherModel(UserManager<AppUser> userManager, IUserRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            ListTeacher = await _repository.Search();
            return Page();
        }
    }
}
