using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.TeacherPage
{
    public class AddTeacherModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public TeacherAddRequest Request { get; set; }
        public AddTeacherModel(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Request.Id = Guid.NewGuid().ToString();
            Request.CreatedDate = DateTime.Now;
            var user = new User()
            {
                Id = Request.Id.ToString(),
                FullName = Request.FullName,
                Login = Request.Email,
                Email = Request.Email,
                UserName = Request.Email,
                Adress = Request.Adress,
                Phone = Request.Phone,
                Type = 1,
                Activated = true,
                RoleId = "teacher",
                CreatedDate = Request.CreatedDate,
                LastModifiedDate = null
            };
            await _userManager.CreateAsync(user, Request.Password);
            return RedirectToPage("/TeacherPage/Teacher");
        }
    }
}
