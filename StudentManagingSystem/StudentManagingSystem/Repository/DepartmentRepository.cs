using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ISmsDbContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepository(ISmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(Department department, CancellationToken cancellationToken = default)
        {
            await _context.Departments.AddAsync(department);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(i => i.Id == id);
            if (department == null) throw new ArgumentException("Can not find !!!");
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Department>> GetAll()
        {
            var list = await _context.Departments.Where(c => c.Status == true).OrderBy(c => c.CreatedDate).ToListAsync();
            return list;
        }

        public async Task<Department> GetById(Guid id)
        {
            var department = await _context.Departments.FirstOrDefaultAsync(i => i.Id == id);
            if (department == null) throw new ArgumentException("Can not find !!!");
            return department;
        }
        
        public async Task<List<Department>> Search()
        {
            var list = await _context.Departments.OrderBy(c => c.CreatedDate).ToListAsync();
            return list;
        }

        public async Task Update(Department department, CancellationToken cancellationToken = default)
        {
            var dept = await _context.Departments.FirstOrDefaultAsync(i => i.Id == department.Id);
            if (dept != null)
            {
                var newDept = _mapper.Map<Department, Department>(department, dept);
                _context.Departments.Update(newDept);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
