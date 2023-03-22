using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Utility;

namespace StudentManagingSystem.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public IndexModel(ILogger<IndexModel> logger, RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager)
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet()
        {
            if (!await _roleManager.RoleExistsAsync(RoleConstant.ADMIN))
            {
                await _roleManager.CreateAsync(new IdentityRole(RoleConstant.ADMIN));
                await _roleManager.CreateAsync(new IdentityRole(RoleConstant.TEACHER));
                await _roleManager.CreateAsync(new IdentityRole(RoleConstant.STUDENT));
            }
            var user = new AppUser
            {
                Id = Guid.NewGuid().ToString(),
                FullName = "Administrator",
                Login = "admin@gmail.com",
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                Type = 2,
                Activated = true,
            };
            await _userManager.CreateAsync(user, "Abc@123");
            await _userManager.AddToRoleAsync(user, RoleConstant.ADMIN);
            return Page();
        }
    }
}