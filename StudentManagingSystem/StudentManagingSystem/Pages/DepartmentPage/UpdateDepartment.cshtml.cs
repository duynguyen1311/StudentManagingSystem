using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using StudentManagingSystem.ViewModel;
using System.Data;

namespace StudentManagingSystem.Pages.DepartmentPage
{
	[Authorize]
	public class UpdateDepartmentModel : PageModel
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        [BindProperty]
        public Department Department { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; }
        public UpdateDepartmentModel(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync(Guid id, int pageIndex)
        {
            Department = await _repository.GetById(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Department.LastModifiedDate = DateTime.Now;
            await _repository.Update(Department);
            return RedirectToPage("/DepartmentPage/Department", new { pageIndex = PageIndex });
        }
    }
}
