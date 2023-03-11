using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Model;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Repository
{
    public class ClassRoomRepository : IClassRoomRepository
    {
        private readonly ISmsDbContext _context;
        private readonly IMapper _mapper;

        public async Task Add(ClassRoom classRoom, CancellationToken cancellationToken = default)
        {
            await _context.ClassRooms.AddAsync(classRoom);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var classRoom = await _context.ClassRooms.FirstOrDefaultAsync(i => i.Id == id);
            if (classRoom == null) throw new ArgumentException("Can not find !!!");
            _context.ClassRooms.Remove(classRoom);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<ClassRoom>> GetAll()
        {
            try
            {
                var list = await _context.ClassRooms
                .Where(c => c.Status == true)
                .OrderBy(c => c.CreatedDate).ToListAsync();
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);  
            }

        }

        public async Task<ClassRoom> GetById(Guid id)
        {
            var classRoom = await _context.ClassRooms.Where(c => c.Status == true).FirstOrDefaultAsync(i => i.Id == id);
            if (classRoom == null) throw new ArgumentException("Can not find !!!");
            return classRoom;
        }

        public async Task<List<ClassRoom>> Search()
        {
            var list = await _context.ClassRooms
                .Include(c => c.Department)
                .Include(c => c.User)
                .OrderBy(c => c.CreatedDate).ToListAsync();
            return list;
        }

        public async Task Update(ClassRoom classRoom, CancellationToken cancellationToken = default)
        {
            var dept = await _context.ClassRooms.FirstOrDefaultAsync(i => i.Id == classRoom.Id);
            if (dept != null)
            {
                var newDept = _mapper.Map<ClassRoom, ClassRoom>(classRoom, dept);
                _context.ClassRooms.Update(newDept);
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
