using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using StudentManagingSystem.Utility;
using System.Data;

namespace StudentManagingSystem.Pages.TeacherPage
{
	[Authorize(Roles = RoleConstant.ADMIN)]
	public class DeleteTeacherModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;

        public DeleteTeacherModel(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            return RedirectToPage("/TeacherPage/Teacher");
        }
    }
}
