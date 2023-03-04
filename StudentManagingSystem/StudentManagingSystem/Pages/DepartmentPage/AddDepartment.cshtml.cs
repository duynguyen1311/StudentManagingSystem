using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.ViewModel;

namespace StudentManagingSystem.Pages.DepartmentPage
{
    public class AddDepartmentModel : PageModel
    {
        private readonly IDepartmentRepository _repository;

        [BindProperty]
        public DepartmentViewModel DepartmentAddRequest { get; set; }

        public AddDepartmentModel(IDepartmentRepository repository)
        {
            _repository = repository;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var dept = new Department
            {
                Id = Guid.NewGuid(),
                DepartmentName = DepartmentAddRequest.DepartmentName,
                DepartmentCode = DepartmentAddRequest.DepartmentCode,
                Status = DepartmentAddRequest.Status,
                CreatedDate = DateTime.Now,
            };

            await _repository.Add(dept);

            return RedirectToPage("/DepartmentPage/Department");
        }

    }
}
