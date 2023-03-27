using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;

namespace StudentManagingSystem.Pages.NotificationPage
{
    [Authorize(Roles = RoleConstant.ADMIN)]
    public class NotificationModel : PageModel
    {
        private readonly INotiRepository _repository;

        public PagedList<Notification> ListNoti { get; set; }
        public int PageIndex { get; set; } = 1;
        public int TotalPage { get; set; }
        public NotificationModel(INotiRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(int pageIndex, int pagesize)
        {
            if (pageIndex == 0) pageIndex = 1;
            PageIndex = pageIndex;
            pagesize = 4;
            ListNoti = await _repository.Search(pageIndex, pagesize);
            TotalPage = (int)(Math.Ceiling(ListNoti.TotalCount / (double)pagesize));
            return Page();
        }
    }
}
