using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Pages.StudentPage
{
    public class StudentModel : PageModel
    {
        private readonly IStudentRepository _repository;

        public List<Student> ListStudent { get; set; }
        public StudentModel(IStudentRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            ListStudent = await _repository.GetAll();
            return Page();
        }
    }
}
