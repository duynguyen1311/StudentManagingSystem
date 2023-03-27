using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;

namespace StudentManagingSystem.Pages.ClassRoomPage
{
    public class ClassRoomModel : PageModel
    {
        private readonly IRoomRepository _repository;
        private readonly UserManager<AppUser> _userManager;
        private readonly IStudentRepository _studentRepository;

        public PagedList<ClassRoom> ListClassRoom { get; set; }
        [BindProperty]
        public string? Keyword { get; set; }
        [BindProperty]
        public bool? Status { get; set; }
        public int PageIndex { get; set; } = 1;
        public int TotalPage { get; set; }
        public ClassRoomModel(IRoomRepository repository,IStudentRepository studentRepository, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
            _studentRepository = studentRepository;
        }
        public async Task<IActionResult> OnGetAsync(string? keyword, bool? status, int pageIndex, int pagesize)
        {
            var user = await _userManager.GetUserAsync(User);
            var role = await _userManager.GetRolesAsync(user);
            if (role.Contains(RoleConstant.TEACHER))
            {
                Keyword = keyword;
                Status = status;
                if (pageIndex == 0) pageIndex = 1;
                PageIndex = pageIndex;
                pagesize = 4;
                ListClassRoom = await _repository.Search(keyword, status,user.Id, pageIndex, pagesize);
                TotalPage = (int)(Math.Ceiling(ListClassRoom.TotalCount / (double)pagesize));
            }
            else if(role.Contains(RoleConstant.STUDENT))
            {
                var st = await _studentRepository.GetById(Guid.Parse(user.Id));
                Keyword = keyword;
                Status = status;
                if (pageIndex == 0) pageIndex = 1;
                PageIndex = pageIndex;
                pagesize = 4;
                ListClassRoom = await _repository.SearchClassByStudent(keyword, status, st.Id, pageIndex, pagesize);
                TotalPage = (int)(Math.Ceiling(ListClassRoom.TotalCount / (double)pagesize));
            }
            else
            {
                Keyword = keyword;
                Status = status;
                if (pageIndex == 0) pageIndex = 1;
                PageIndex = pageIndex;
                pagesize = 4;
                ListClassRoom = await _repository.Search(keyword, status, null, pageIndex, pagesize);
                TotalPage = (int)(Math.Ceiling(ListClassRoom.TotalCount / (double)pagesize));
            }
            
            return Page();
        }
        public async Task<IActionResult> Lists(Guid id)
        {
            // load data for the item with the specified ID
            var item = await _repository.ListStudentByClass(id);
            return Partial("_ListStudentPartial", item);
        }
    }
}
