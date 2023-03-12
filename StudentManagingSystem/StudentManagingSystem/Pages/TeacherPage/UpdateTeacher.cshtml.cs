using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.TeacherPage
{
    public class UpdateTeacherModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        [BindProperty]
        public User Teacher { get; set; }
        public UpdateTeacherModel(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            //var teacher = await _userManager.FindByIdAsync(id);
            Teacher = await _userManager.FindByIdAsync(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            /*Teacher.LastModifiedDate = DateTime.Now;
            Teacher.Type = 1;
            var user = _mapper.Map<User>(Teacher);*/
            await _userManager.UpdateAsync(Teacher);
            return RedirectToPage("/TeacherPage/Teacher");
        }
    }
}
