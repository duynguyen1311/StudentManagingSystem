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

        public List<ClassRoomViewModel> ListClass { get; set; }
        public ClassRoomModel(IClassRoomRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            var list = await _repository.Search();
            ListClass = _mapper.Map<List<ClassRoomViewModel>>(list);
            return Page();
        }
    }
}
