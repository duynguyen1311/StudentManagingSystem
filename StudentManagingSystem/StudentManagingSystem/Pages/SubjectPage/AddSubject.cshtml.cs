using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;
using StudentManagingSystem.ViewModel;
using System.Data;

namespace StudentManagingSystem.Pages.SubjectPage
{
	[Authorize(Roles = RoleConstant.ADMIN)]
	public class AddSubjectModel : PageModel
    {
        private readonly ISubjectRepository _repository;
        private readonly IMapper _mapper;

        [BindProperty]
        public SubjectViewModel SubjectAddRequest { get; set; }

        public AddSubjectModel(ISubjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IActionResult> OnPostAsync()
        {

            var dept = _mapper.Map<Subject>(SubjectAddRequest);
            dept.Id = Guid.NewGuid();
            dept.CreatedDate = DateTime.Now;
            dept.LastModifiedDate = null;
            await _repository.Add(dept);

            return RedirectToPage("/SubjectPage/Subject");
        }
    }
}
