using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using StudentManagingSystem.Model;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.StudentPage
{
    [Authorize(Roles =RoleConstant.ADMIN)]
    public class AddStudentModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ISmsDbContext _context;
        private readonly IToastNotification _notify;

        [BindProperty]
        public StudentAddRequest Request { get; set; }
        public List<ClassRoom> listClass { get; set; }
        public AddStudentModel(IStudentRepository repository,IRoomRepository roomRepository, IMapper mapper, UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, ISmsDbContext context, IToastNotification notify)
        {
            _repository = repository;
            _roomRepository = roomRepository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _notify = notify;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            listClass = await _roomRepository.GetAll();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            Request.Id = Guid.NewGuid();
            Request.CreatedDate = DateTime.Now;
            var student = _mapper.Map<Student>(Request);
            var check = await _repository.CheckAddExistEmail(Request.Email);
            if(!check)
            {
                ViewData["Title"] = "Email has been existed !";
                listClass = await _roomRepository.GetAll();
                return Page();
            }
            await _repository.Add(student);
            var user = new AppUser()
            {
                Id = student.Id.ToString(),
                FullName = student.StudentName,
                Login = student.Email,
                Email = student.Email,
                UserName = student.Email,
                Adress = student.Address,
                Gender = student.Gender,
                DOB = student.DOB,
                Phone = student.Phone,
                Type = 0,
            };
            if (Request.Status == true)
            {
                user.Activated = true;
            }
            else
            {
                user.Activated = false;
            }
            var res = await _userManager.CreateAsync(user, Request.Password);
            if (res.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, RoleConstant.STUDENT);
            }
            return RedirectToPage("/StudentPage/Student");
        }
    }
}
