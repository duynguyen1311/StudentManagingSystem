using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ISmsDbContext _context;

        public StudentRepository(ISmsDbContext context)
        {
            _context = context;
        }
        public async Task Add(Student student, CancellationToken cancellationToken = default)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var student = await _context.Students.FirstOrDefaultAsync(i => i.Id == id);
            if (student == null) throw new ArgumentException("Can not find !!!");
            _context.Students.Remove(student);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Student>> GetAll()
        {
            var list = await _context.Students.ToListAsync();
            return list;
        }

        public async Task<Student> GetById(Guid id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(i => i.Id == id);
            if (student == null) throw new ArgumentException("Can not find !!!");
            return student;
        }

        public async Task Update(Student student, CancellationToken cancellationToken = default)
        {
            /*var dept = await _context.Departments.FirstOrDefaultAsync(i => i.Id == department.Id);
            if (dept != null)
            {
                dept.DepartmentName = department.DepartmentName;
                dept.DepartmentCode = department.DepartmentCode;
                dept.Status = department.Status;
                await _context.SaveChangesAsync(cancellationToken);
            }*/
        }
    }
}
