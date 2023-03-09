using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.StudentPage
{
    public class AddStudentModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public StudentAddRequest Request { get; set; }
        public List<ClassRoom> listClass { get; set; }
        public AddStudentModel(IStudentRepository repository, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }

        /*public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }*/
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                Request.Id = Guid.NewGuid();
                Request.CreatedDate = DateTime.Now;
                var student = _mapper.Map<Student>(Request);
                await _repository.Add(student);
                var user = new User()
                {
                    Id = student.Id.ToString(),
                    FullName = student.StudentName,
                    Login = student.Email,
                    Email = student.Email,
                    UserName = student.Email,
                    Adress = student.Address,
                    Phone = student.Phone,
                    Type = 0,
                    Activated = true,
                };
                await _userManager.CreateAsync(user, Request.Password);
                await CreateUserRoles(user, user.UserRoles.Select(iur => iur.Role.Name).ToHashSet());
                return RedirectToPage("StudentPage/Student");
            }
            return Page();
        }

        private async Task CreateUserRoles(User user, IEnumerable<string> roles)
        {
            if (roles == null || !roles.Any()) return;

            foreach (var role in roles) await _userManager.AddToRoleAsync(user, role);
        }
    }
}
