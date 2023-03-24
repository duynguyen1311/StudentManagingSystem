using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Utility;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.TeacherPage
{
    public class AddTeacherModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        [BindProperty]
        public TeacherAddRequest Request { get; set; }
        public AddTeacherModel(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
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
