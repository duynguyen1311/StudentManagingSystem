using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.DepartmentPage
{
    [Authorize]
    public class DepartmentModel : PageModel
    {
        private readonly IDepartmentRepository _repository;

        public PagedList<Department> ListDepartment { get; set; }
        [BindProperty]
        public string? Keyword { get; set; }
        [BindProperty]
        public bool? Status { get; set; }
        public int PageIndex { get; set; } = 1;
        public int TotalPage { get; set; }
        public DepartmentModel(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnGetAsync(string? keyword, bool? status,int pageIndex, int pagesize)
        {
            Keyword = keyword;
            Status = status;
            if (pageIndex == 0) pageIndex = 1;
            PageIndex = pageIndex;
            pagesize = 4;
            ListDepartment = await _repository.Search(keyword,status, pageIndex, pagesize);
            TotalPage = (int)(Math.Ceiling(ListDepartment.TotalCount / (double)pagesize));
            return Page();
        }
        
    }
}
