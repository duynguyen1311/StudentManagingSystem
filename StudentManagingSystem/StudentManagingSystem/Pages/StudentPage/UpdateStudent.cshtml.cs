using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Pages.StudentPage
{
    public class UpdateStudentModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        [BindProperty]
        public Student Student { get; set; }
        public UpdateStudentModel(IStudentRepository repository, IMapper mapper, UserManager<User> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Student = await _repository.GetById(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Student.LastModifiedDate = DateTime.Now;
            await _repository.Update(Student);
            var user = await _userManager.FindByIdAsync(Student.Id.ToString());
            if(Student.Status == true)
            {
                user.Activated = true;
            }
            else
            {
                user.Activated = false;
            }
            await _userManager.UpdateAsync(user);
            return RedirectToPage("/StudentPage/Student");
        }
    }
}
