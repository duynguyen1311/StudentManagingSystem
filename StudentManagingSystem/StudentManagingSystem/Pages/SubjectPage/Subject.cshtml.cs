using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace StudentManagingSystem.Pages.SubjectPage
{
    public class SubjectModel : PageModel
    {
        private readonly ISubjectRepository _repository;

        public PagedList<Subject> ListSubject { get; set; }
        [BindProperty]
        public string? Keyword { get; set; }
        [BindProperty]
        public bool? Status { get; set; }
        public int PageIndex { get; set; } = 1;
        public int TotalPage { get; set; }
        public SubjectModel(ISubjectRepository repository)
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
            ListSubject = await _repository.Search(keyword, status, pageIndex, pagesize);
            TotalPage = (int)(Math.Ceiling(ListSubject.TotalCount / (double)pagesize));
            return Page();
        }
    }
}
