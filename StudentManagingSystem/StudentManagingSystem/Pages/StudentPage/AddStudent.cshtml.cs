using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NToastNotify;
using StudentManagingSystem.Model;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.StudentPage
{
    public class AddStudentModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ISmsDbContext _context;
        private readonly IToastNotification _notify;

        [BindProperty]
        public StudentAddRequest Request { get; set; }
        public List<ClassRoom> listClass { get; set; }
        public AddStudentModel(IStudentRepository repository, IMapper mapper, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, ISmsDbContext context, IToastNotification notify)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _notify = notify;
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
            var user = new AppUser()
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
            var res = await _userManager.CreateAsync(user, Request.Password);
            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RoleConstant.STUDENT);
                _notify.AddSuccessToastMessage("User created successfully ");
            }
            else
            {
                _notify.AddErrorToastMessage("User not created successfully ");
            }
            return RedirectToPage("/StudentPage/Student");
        }
    }
}
