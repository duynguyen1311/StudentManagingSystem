using AutoMapper;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Model;
using StudentManagingSystem.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace StudentManagingSystem.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ISmsDbContext _context;
        private readonly IMapper _mapper;

        public SubjectRepository(ISmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(Subject subject, CancellationToken cancellationToken = default)
        {
            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(i => i.Id == id);
            if (subject == null) throw new ArgumentException("Can not find !!!");
            _context.Subjects.Remove(subject);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Subject>> GetAll()
        {
            var list = await _context.Subjects.Where(c => c.Status == true).OrderByDescending(c => c.CreatedDate).ToListAsync();
            return list;
        }

        public async Task<Subject> GetById(Guid id)
        {
            var subject = await _context.Subjects.FirstOrDefaultAsync(i => i.Id == id);
            if (subject == null) throw new ArgumentException("Can not find !!!");
            return subject;
        }

        public async Task<List<Subject>> Search()
        {
            var list = await _context.Subjects.OrderByDescending(c => c.CreatedDate).ToListAsync();
            return list;
        }

        public async Task Update(Subject subject, CancellationToken cancellationToken = default)
        {
            var dept = await _context.Subjects.FirstOrDefaultAsync(i => i.Id == subject.Id);
            if (dept != null)
            {
                var newDept = _mapper.Map<Subject, Subject>(subject, dept);
                _context.Subjects.Update(newDept);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
