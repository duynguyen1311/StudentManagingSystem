using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using System.Data;

namespace StudentManagingSystem.Pages.SubjectPage
{
	[Authorize(Roles = RoleConstant.ADMIN)]
	public class DeleteSubjectModel : PageModel
    {
        private readonly ISubjectRepository _repository;

        public DeleteSubjectModel(ISubjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            await _repository.Delete(id);
            return RedirectToPage("/SubjectPage/Subject");
        }
    }
}
