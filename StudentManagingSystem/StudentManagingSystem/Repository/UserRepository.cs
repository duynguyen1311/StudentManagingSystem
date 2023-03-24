using AutoMapper;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentManagingSystem.Repository.IRepository;

namespace StudentManagingSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ISmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public UserRepository(ISmsDbContext context, IMapper mapper, UserManager<AppUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<AppUser>> GetAll()
        {
            var list = await _context.AppUsers.Where(i => i.Activated && i.Type == 1).OrderByDescending(i => i.CreatedDate).ToListAsync();
            return list;
        }
        public async Task<bool> CheckAddExistEmail(string email, CancellationToken cancellationToken = default)
        {
            List<AppUser> listS = await _context.AppUsers.ToListAsync();
            foreach (var cus in listS)
            {
                if (email == cus.Email)
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<AppUser> GetById(string id)
        {
            var User = await _userManager.FindByIdAsync(id);
            if (User == null) throw new ArgumentException("Can not find !!!");
            return User;
        }

        public async Task<List<AppUser>> Search()
        {
            var list = await _context.AppUsers.Where(i => i.Activated && i.Type == 1).OrderByDescending(i => i.CreatedDate).ToListAsync();
            return list;
        }
    }
}
