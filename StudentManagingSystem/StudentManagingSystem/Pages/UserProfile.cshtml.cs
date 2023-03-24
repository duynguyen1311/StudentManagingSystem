using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Internal;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using StudentManagingSystem.ViewModel;
using System.Data;

namespace StudentManagingSystem.Pages
{
    public class UserProfileModel : PageModel
    {
		private readonly IStudentRepository _studentRepository;
		private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        [BindProperty]
        public UserProfileViewModel Profile { get; set; }
        public UserProfileModel(IStudentRepository studentRepository, IUserRepository userRepository,UserManager<AppUser> userManager, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _userRepository = userRepository;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var role = await _userManager.GetRolesAsync(user);
            if ((role.Contains(RoleConstant.ADMIN)) || (role.Contains(RoleConstant.TEACHER)))
            {
                Profile = _mapper.Map<UserProfileViewModel>(user);
                return Page();
            }
            var student = await _studentRepository.GetById(Guid.Parse(id));
            Profile = _mapper.Map<UserProfileViewModel>(user);
            Profile.StudentCode = student.StudentCode;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
				var user = await _userManager.FindByIdAsync(Profile.Id);
                var role = await _userManager.GetRolesAsync(user);
                if ((role.Contains(RoleConstant.ADMIN)) || (role.Contains(RoleConstant.TEACHER)))
                {
                    _mapper.Map(Profile, user);
                    await _userManager.UpdateAsync(user);
                    return Page();
                }
				var student = await _studentRepository.GetById(Guid.Parse(Profile.Id));
                Profile.StudentCode = student.StudentCode;
				_mapper.Map(Profile, user);
				_mapper.Map(Profile, student);
				await _userManager.UpdateAsync(user);
				await _studentRepository.Update(student);
				return Page();
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return RedirectToPage("Error");
			}
		}

    }
}
