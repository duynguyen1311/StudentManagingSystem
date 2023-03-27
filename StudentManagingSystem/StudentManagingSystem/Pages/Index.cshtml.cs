using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;

namespace StudentManagingSystem.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly INotiRepository _repository;
        
        public Notification Notification { get; set; }
        public List<Notification> listNoti { get; set; }
        public IndexModel(ILogger<IndexModel> logger, RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager, INotiRepository repository)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _repository = repository;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            listNoti = await _repository.GetAll();
            return Page();
        }
        public async Task<IActionResult> OnGetDetail(Guid id)
        {
            Notification = await _repository.GetById(id);
            return Page();
        }
    }
}