using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using StudentManagingSystem.ViewModel;
using System.Data;

namespace StudentManagingSystem.Pages.TeacherPage
{
    [Authorize(Roles = RoleConstant.ADMIN)]

    public class UpdateTeacherModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        [BindProperty]
        public AppUser Teacher { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        public UpdateTeacherModel(UserManager<AppUser> userManager, IMapper mapper)
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
            var user = await _userManager.FindByIdAsync(Teacher.Id);
            user = _mapper.Map(Teacher,user);
            user.LastModifiedDate = DateTime.Now;
            user.Type = 1;
            await _userManager.UpdateAsync(user);
            return RedirectToPage("/TeacherPage/Teacher", new { pageIndex = PageIndex });
        }
    }
}
