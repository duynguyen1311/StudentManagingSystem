using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using System.Data;

namespace StudentManagingSystem.Pages.StudentPage
{
	[Authorize(Roles = RoleConstant.ADMIN)]
	public class StudentModel : PageModel
    {
        private readonly IStudentRepository _repository;

        public PagedList<Student> ListStudent { get; set; }
        [BindProperty]
        public string? Keyword { get; set; }
        [BindProperty]
        public bool? Status { get; set; }
        public int PageIndex { get; set; } = 1;
        public int TotalPage { get; set; }
        public StudentModel(IStudentRepository repository)
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
            ListStudent = await _repository.GetAll(keyword, status, pageIndex, pagesize);
            TotalPage = (int)(Math.Ceiling(ListStudent.TotalCount / (double)pagesize));
            return Page();
        }
    }
}
