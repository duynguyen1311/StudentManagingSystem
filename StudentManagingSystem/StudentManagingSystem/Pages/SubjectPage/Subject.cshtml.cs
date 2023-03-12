using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Pages.SubjectPage
{
    public class SubjectModel : PageModel
    {
        private readonly ISubjectRepository _repository;

        public List<Subject> ListSubject { get; set; }
        public SubjectModel(ISubjectRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            ListSubject = await _repository.Search();
            return Page();
        }
    }
}
