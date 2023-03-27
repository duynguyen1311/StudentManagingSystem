using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using System.Data;

namespace StudentManagingSystem.Pages.NotificationPage
{
    [Authorize(Roles = RoleConstant.ADMIN)]
    public class DeleteNotificationModel : PageModel
    {
        private readonly INotiRepository _repository;

        public DeleteNotificationModel(INotiRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            await _repository.Delete(id);
            return RedirectToPage("/NotificationPage/Notification");
        }
    }
}
