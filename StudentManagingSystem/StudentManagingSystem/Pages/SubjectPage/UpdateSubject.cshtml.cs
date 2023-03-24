using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Pages.SubjectPage
{
    public class UpdateSubjectModel : PageModel
    {
        private readonly ISubjectRepository _repository;
        private readonly IMapper _mapper;

        [BindProperty]
        public Subject Subject { get; set; }
        public UpdateSubjectModel(ISubjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Subject = await _repository.GetById(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Subject.LastModifiedDate = DateTime.Now;
            await _repository.Update(Subject);
            return RedirectToPage("/SubjectPage/Subject");
        }
    }
}