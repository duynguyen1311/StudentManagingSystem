using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Pages.ClassRoomPage
{
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
