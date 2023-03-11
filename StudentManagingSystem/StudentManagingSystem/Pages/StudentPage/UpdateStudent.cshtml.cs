using AutoMapper;
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

        [BindProperty]
        public Student Student { get; set; }
        public UpdateStudentModel(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            return RedirectToPage("/StudentPage/Student");
        }
    }
}
