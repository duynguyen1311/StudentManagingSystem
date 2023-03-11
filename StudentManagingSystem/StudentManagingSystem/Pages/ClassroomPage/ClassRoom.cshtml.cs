using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.ClassroomPage
{
    public class ClassRoomModel : PageModel
    {
        private readonly IClassRoomRepository _repository;
        private readonly IMapper _mapper;

        public List<ClassRoom> ListClass { get; set; }
        public ClassRoomModel(IClassRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            ListClass = await _repository.GetAll();
            /*ListClass = _mapper.Map<List<R>>(list);*/
            return Page();
        }
    }
}
