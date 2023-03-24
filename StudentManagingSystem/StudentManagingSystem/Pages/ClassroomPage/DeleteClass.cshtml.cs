using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using System.Data;

namespace StudentManagingSystem.Pages.ClassRoomPage
{
	[Authorize(Roles = RoleConstant.ADMIN)]
	public class DeleteClassModel : PageModel
    {
        private readonly IRoomRepository _repository;

        public DeleteClassModel(IRoomRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            await _repository.Delete(id);
            return RedirectToPage("/ClassRoomPage/ClassRoom");
        }
    }
}
