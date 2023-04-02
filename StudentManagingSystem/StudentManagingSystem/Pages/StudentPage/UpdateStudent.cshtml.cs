using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using System.Data;

namespace StudentManagingSystem.Pages.StudentPage
{
    [Authorize(Roles = RoleConstant.ADMIN)]
    public class UpdateStudentModel : PageModel
    {
        private readonly IStudentRepository _repository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        [BindProperty]
        public Student Student { get; set; }
        public List<ClassRoom> listClass { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        public UpdateStudentModel(IStudentRepository repository, IRoomRepository roomRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _roomRepository = roomRepository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            listClass = await _roomRepository.GetAll();
            Student = await _repository.GetById(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Student.LastModifiedDate = DateTime.Now;
            await _repository.Update(Student);
            var user = await _userManager.FindByIdAsync(Student.Id.ToString());
            if (Student.Status == true)
            {
                user.Activated = true;
            }
            else
            {
                user.Activated = false;
            }
            await _userManager.UpdateAsync(user);
            return RedirectToPage("/StudentPage/Student", new { pageIndex = PageIndex });
        }
    }
}
