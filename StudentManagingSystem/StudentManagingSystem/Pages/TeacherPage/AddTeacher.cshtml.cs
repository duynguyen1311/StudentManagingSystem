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
	public class AddTeacherModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _repository;

        [BindProperty]
        public TeacherAddRequest Request { get; set; }
        public AddTeacherModel(IMapper mapper, UserManager<AppUser> userManager, IUserRepository repository)
        {
            _mapper = mapper;
            _userManager = userManager;
            _repository = repository;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Request.Id = Guid.NewGuid().ToString();
                Request.CreatedDate = DateTime.Now;
                var user = new AppUser()
                {
                    Id = Request.Id.ToString(),
                    FullName = Request.FullName,
                    Login = Request.Email,
                    Email = Request.Email,
                    UserName = Request.Email,
                    Adress = Request.Adress,
                    Phone = Request.Phone,
                    Gender = Request.Gender,
                    DOB = Request.DOB,
                    Type = 1,
                    Activated = true,
                    CreatedDate = Request.CreatedDate,
                    LastModifiedDate = null
                };
                var check = await _repository.CheckAddExistEmail(Request.Email);
                if (!check)
                {
                    ViewData["Title"] = "Email has been existed !";
                    return Page();
                }
                var res = await _userManager.CreateAsync(user, Request.Password);
                if (res.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, RoleConstant.TEACHER);
                    return RedirectToPage("/TeacherPage/Teacher");
                }
                else
                {
                    return Page();
                }
               
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }
    }
}
