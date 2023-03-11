using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Pages.ClassRoomPage
{
    public class DeleteClassRoomModel : PageModel
    {
        private readonly IClassRoomRepository _repository;

        public DeleteClassRoomModel(IClassRoomRepository repository)
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
