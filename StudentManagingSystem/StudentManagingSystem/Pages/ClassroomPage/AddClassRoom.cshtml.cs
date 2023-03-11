using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.ClassroomPage
{
    public class AddClassRoomModel : PageModel
    {
        private readonly IClassRoomRepository _repository;
        private readonly IDepartmentRepository _deptRepository;
        private readonly IMapper _mapper;


        [BindProperty]
        public ClassRoomAddRequest ClassAddRequest { get; set; }
        public SelectList Depts { get; set; }
        public AddClassRoomModel(IClassRoomRepository repository,IDepartmentRepository deptRepository, IMapper mapper)
        {
            _repository = repository;
            _deptRepository = deptRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            Depts = new SelectList(await _deptRepository.GetAll(),"Id","DepartmentName");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var classRoom = _mapper.Map<ClassRoom>(ClassAddRequest);
            classRoom.DepartmentId = Guid.Parse("4942CCC5-BAF1-49F0-9F57-44539DED7AAA");
            classRoom.Id = Guid.NewGuid();
            classRoom.CreatedDate = DateTime.Now;
            classRoom.LastModifiedDate = null;
            var test = new ClassRoom()
            {
                Id = Guid.NewGuid(),
                ClassName = "ClassA",
                ClassCode = "CA",
                DepartmentId = Guid.Parse("4942CCC5-BAF1-49F0-9F57-44539DED7AAA"),
                Status = true,
                UserId = "ababa489-bf14-41be-b6e3-ac90c9d759a5"
            };
            await _repository.Add(test);
            return RedirectToPage("/ClassRoomPage/ClassRoom");
        }
    }
}
