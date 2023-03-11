using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Pages.ClassroomPage
{
    public class UpdateClassRoomModel : PageModel
    {
        private readonly IClassRoomRepository _repository;
        private readonly IMapper _mapper;

        [BindProperty]
        public ClassRoom ClassRoom { get; set; }
        public UpdateClassRoomModel(IClassRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            ClassRoom = await _repository.GetById(id);
            return Page();
        }
        /*public async Task<IActionResult> OnPostAsync()
        {
            Department.LastModifiedDate = DateTime.Now;
            await _repository.Update(Department);
            return RedirectToPage("/DepartmentPage/Department");
        }*/
    }
}
