using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using System.Data;

namespace StudentManagingSystem.Pages.NotificationPage
{
    [Authorize(Roles = RoleConstant.ADMIN)]
    public class UpdateNotificationModel : PageModel
    {
        private readonly INotiRepository _repository;
        private readonly IMapper _mapper;

        [BindProperty]
        public Notification Notification { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        public UpdateNotificationModel(INotiRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Notification = await _repository.GetById(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Notification.LastModifiedDate = DateTime.Now;
            await _repository.Update(Notification);
            return RedirectToPage("/NotificationPage/Notification", new { pageIndex = PageIndex });
        }
    }
}
