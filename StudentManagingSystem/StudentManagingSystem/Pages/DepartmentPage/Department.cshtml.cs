using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.DepartmentPage
{
    [Authorize]
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
            ListDepartment = await _repository.Search();
            return Page();
        }
        
    }
}
