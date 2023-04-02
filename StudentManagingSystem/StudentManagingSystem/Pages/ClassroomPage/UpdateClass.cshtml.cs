using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using System.Data;

namespace StudentManagingSystem.Pages.ClassRoomPage
{
	[Authorize]
	public class UpdateClassModel : PageModel
    {
        private readonly IRoomRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        [BindProperty]
        public ClassRoom ClassRoom { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        public List<Department> listDept { get; set; }
        public List<AppUser> listUser { get; set; }
        public UpdateClassModel(IRoomRepository repository, IDepartmentRepository departmentRepository, IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            listDept = await _departmentRepository.GetAll();
            listUser = await _userRepository.GetAll();
            ClassRoom = await _repository.GetById(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ClassRoom.LastModifiedDate = DateTime.Now;
            await _repository.Update(ClassRoom);
            return RedirectToPage("/ClassRoomPage/ClassRoom", new { pageIndex = PageIndex });
        }
    }
}
