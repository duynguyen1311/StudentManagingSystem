using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using StudentManagingSystem.ViewModel;
using System.Data;

namespace StudentManagingSystem.Pages.NotificationPage
{
    [Authorize(Roles = RoleConstant.ADMIN)]
    public class AddNotificationModel : PageModel
    {
        private readonly INotiRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        [BindProperty]
        public NotificationAddRequest NotificationAddRequest { get; set; }

        public AddNotificationModel(INotiRepository repository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
				var dept = _mapper.Map<Notification>(NotificationAddRequest);
				dept.Id = Guid.NewGuid();
				dept.CreatedDate = DateTime.Now;
                var user = await _userManager.GetUserAsync(User);
                dept.CreatedBy = user.FullName;
				dept.LastModifiedDate = null;
				await _repository.Add(dept);

				return RedirectToPage("/NotificationPage/Notification");
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return RedirectToPage("/Error");
			}
        }
    }
}
