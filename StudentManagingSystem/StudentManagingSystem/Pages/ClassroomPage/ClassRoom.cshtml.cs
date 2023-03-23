using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Pages.ClassRoomPage
{
    public class ClassRoomModel : PageModel
    {
        private readonly IRoomRepository _repository;
        public List<ClassRoom> ListClassRoom { get; set; }
        public ClassRoomModel(IRoomRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            ListClassRoom = await _repository.Search();
            return Page();
        }
    }
}
