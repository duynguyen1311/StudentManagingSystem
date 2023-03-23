using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.ClassRoomPage
{
    public class AddClassModel : PageModel
    {
        private readonly IRoomRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        [BindProperty]
        public ClassRoomAddRequest ClassRoomAddRequest { get; set; }
        public List<Department> listDept{ get; set; }
        public List<AppUser> listUser { get; set; }
        public AddClassModel(IRoomRepository repository,IDepartmentRepository departmentRepository,IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            listDept = await _departmentRepository.GetAll();
            listUser = await _userRepository.GetAll();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {

            var dept = _mapper.Map<ClassRoom>(ClassRoomAddRequest);
            dept.Id = Guid.NewGuid();
            dept.CreatedDate = DateTime.Now;
            dept.LastModifiedDate = null;
            await _repository.Add(dept);

            return RedirectToPage("/ClassRoomPage/ClassRoom");
        }
    }
}
