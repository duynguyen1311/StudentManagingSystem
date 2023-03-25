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
        [BindProperty]
        public string? Keyword { get; set; }
        [BindProperty]
        public bool? Status { get; set; }
        public DepartmentModel(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(string? keyword, bool? status)
        {
            Keyword = keyword;
            Status = status;
            ListDepartment = await _repository.Search(keyword,status);
            return Page();
        }
        
    }
}
