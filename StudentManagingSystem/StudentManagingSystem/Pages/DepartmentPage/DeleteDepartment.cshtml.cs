using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using System.Data;

namespace StudentManagingSystem.Pages.DepartmentPage
{
	[Authorize(Roles = RoleConstant.ADMIN)]
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
