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

namespace StudentManagingSystem.Pages.StudentPage
{
	[Authorize(Roles = RoleConstant.ADMIN)]
	public class DeleteStudentModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ISmsDbContext _context;

        [BindProperty]
        public StudentAddRequest Request { get; set; }
        public List<ClassRoom> listClass { get; set; }
        public DeleteStudentModel(IStudentRepository repository, IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ISmsDbContext context)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            await _repository.Delete(id);
            var user = await _userManager.FindByIdAsync(id.ToString());
            await _userManager.DeleteAsync(user);
            return RedirectToPage("/StudentPage/Student");
        }
    }
}
