using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Pages.DepartmentPage
{
    public class DeleteDepartmentModel : PageModel
    {
        private readonly IDepartmentRepository _repository;

        public DeleteDepartmentModel(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            await _repository.Delete(id);
            return RedirectToPage("/DepartmentPage/Department");
        }
    }
}
