using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Repository.IRepository;
using StudentManagingSystem.Utility;

namespace StudentManagingSystem.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ISmsDbContext _context;
        private readonly IMapper _mapper;

        public RoomRepository(ISmsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task Add(ClassRoom classRoom, CancellationToken cancellationToken = default)
        {
            await _context.ClassRooms.AddAsync(classRoom);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var c = await _context.ClassRooms.FirstOrDefaultAsync(i => i.Id == id);
            _context.ClassRooms.Remove(c);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ClassRoom>> GetAll()
        {
            var list = await _context.ClassRooms.Where(i => i.Status == true).OrderByDescending(i => i.CreatedDate).ToListAsync();
            return list;
        }

        public async Task<ClassRoom> GetById(Guid id)
        {
            var c = await _context.ClassRooms.FirstOrDefaultAsync(i => i.Id == id);
            return c;
        }

        public async Task<PagedList<ClassRoom>> Search(string? keyword, bool? status, int page, int pagesize)
        {
            var query = _context.ClassRooms.AsQueryable();
            var res = await query.ToListAsync();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(c => (!string.IsNullOrEmpty(c.ClassName) && c.ClassName.Contains(keyword.ToLower().Trim()))
                                      || (!string.IsNullOrEmpty(c.ClassCode) && c.ClassCode.Contains(keyword.ToLower().Trim())));
            }
            if (status != null)
            {
                query = query.Where(c => c.Status == status);
            }
            var list = await query.Include(i => i.Department).Include(i => i.User).OrderByDescending(c => c.CreatedDate)
                .Skip((page - 1) * pagesize)
                .Take(pagesize).ToListAsync();
            return new PagedList<ClassRoom>
            {
                Data = list,
                TotalCount = res.Count
            };
        }

        public async Task Update(ClassRoom classRoom, CancellationToken cancellationToken = default)
        {
            var c = await _context.ClassRooms.FirstOrDefaultAsync(i => i.Id == classRoom.Id);
            if (c != null)
            {
                var newC = _mapper.Map<ClassRoom, ClassRoom>(classRoom, c);
                _context.ClassRooms.Update(newC);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
