using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.DepartmentPage
{
    public class DepartmentModel : PageModel
    {
        private readonly IDepartmentRepository _repository;

        public List<Department> ListDepartment { get; set; }
        
        public DepartmentModel(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            ListDepartment = await _repository.GetAll();
            return Page();
        }
        
    }
}
