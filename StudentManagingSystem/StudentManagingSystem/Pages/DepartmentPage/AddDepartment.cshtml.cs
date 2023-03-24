using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using StudentManagingSystem.ViewModel;
using System.Data;

namespace StudentManagingSystem.Pages.DepartmentPage
{
	[Authorize(Roles = RoleConstant.ADMIN)]
	public class AddDepartmentModel : PageModel
    {
        private readonly IDepartmentRepository _repository;
        private readonly IMapper _mapper;

        [BindProperty]
        public DepartmentViewModel DepartmentAddRequest { get; set; }

        public AddDepartmentModel(IDepartmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
				var dept = _mapper.Map<Department>(DepartmentAddRequest);
				dept.Id = Guid.NewGuid();
				dept.CreatedDate = DateTime.Now;
				dept.LastModifiedDate = null;
				await _repository.Add(dept);

				return RedirectToPage("/DepartmentPage/Department");
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = ex.Message;
				return RedirectToPage("/Error");
			}
        }

    }
}
