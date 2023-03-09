using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages
{
    public class RegisterModel : PageModel
    {
        /*private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        [BindProperty]
        public RegisterViewModel Register { get; set; }

        public RegisterModel(UserManager<User> userManager,SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = new User()
                {
                    UserName = Register.Email,
                    Email = Register.Email,
                };
                var result = await userManager.CreateAsync(user, Register.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToPage("Index");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return Page();
        }*/
    }
}
