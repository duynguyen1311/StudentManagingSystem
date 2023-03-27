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
        public async Task<IActionResult> Details(Guid id)
        {
            // load data for the item with the specified ID
            var item = await _repository.GetById(id);

            return Partial("_NotificationPartial", item);
        }
    }
}