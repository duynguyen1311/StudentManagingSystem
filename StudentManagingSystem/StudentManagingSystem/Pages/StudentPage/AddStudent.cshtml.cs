using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.StudentPage
{
    public class AddStudentModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ISmsDbContext _context;

        [BindProperty]
        public StudentAddRequest Request { get; set; }
        public List<ClassRoom> listClass { get; set; }
        public AddStudentModel(IStudentRepository repository, IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, ISmsDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        /*public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }*/
        public async Task<IActionResult> OnPostAsync()
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
            await CreateUserRoles(user.Id, "student");
            return RedirectToPage("StudentPage/Student");
        }
        
        private async Task CreateUserRoles(string id, string role, CancellationToken cancellation = default)
        {
            if (role == null || !role.Any()) return;

            var newUR = new UserRole()
            {
                UserId = id,
                RoleId = role
            };
            await _context.UserRoles.AddAsync(newUR);
            await _context.SaveChangesAsync(cancellation);
        }
    }
}
