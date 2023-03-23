using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Repository.IRepository;

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

        public async Task<List<ClassRoom>> Search()
        {
            var list = await _context.ClassRooms.Include(i => i.Department).Include(i => i.User).OrderByDescending(i => i.CreatedDate).ToListAsync();
            return list;
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
