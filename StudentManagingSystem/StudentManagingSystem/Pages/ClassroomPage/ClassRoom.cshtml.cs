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
        public PagedList<ClassRoom> ListClassRoom { get; set; }
        [BindProperty]
        public string? Keyword { get; set; }
        [BindProperty]
        public bool? Status { get; set; }
        public int PageIndex { get; set; } = 1;
        public int TotalPage { get; set; }
        public ClassRoomModel(IRoomRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(string? keyword, bool? status, int pageIndex, int pagesize)
        {
            Keyword = keyword;
            Status = status;
            if (pageIndex == 0) pageIndex = 1;
            PageIndex = pageIndex;
            pagesize = 4;
            ListClassRoom = await _repository.Search(keyword, status, pageIndex, pagesize);
            TotalPage = (int)(Math.Ceiling(ListClassRoom.TotalCount / (double)pagesize));
            return Page();
        }
    }
}
