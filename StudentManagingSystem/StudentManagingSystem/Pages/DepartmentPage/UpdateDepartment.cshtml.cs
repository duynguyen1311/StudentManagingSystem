using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.DepartmentPage
{
    public class UpdateDepartmentModel : PageModel
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        [BindProperty]
        public Department Department { get; set; }
        public UpdateDepartmentModel(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            Department = await _repository.GetById(id);
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            Department.LastModifiedDate = DateTime.Now;
            await _repository.Update(Department);
            return RedirectToPage("/DepartmentPage/Department");
        }
    }
}
