using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using System.Data;

namespace StudentManagingSystem.Pages.StudentPage
{
	[Authorize(Roles = RoleConstant.ADMIN)]
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
