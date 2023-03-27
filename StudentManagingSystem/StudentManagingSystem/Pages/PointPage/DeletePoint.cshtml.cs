using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;

namespace StudentManagingSystem.Pages.PointPage
{
    [Authorize(Roles =RoleConstant.ADMIN)]
    public class DeletePointModel : PageModel
    {
        private readonly IPointRepository _repository;

        public DeletePointModel(IPointRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            await _repository.Delete(id);
            return RedirectToPage("/PointPage/Point");
        }
    }
}
