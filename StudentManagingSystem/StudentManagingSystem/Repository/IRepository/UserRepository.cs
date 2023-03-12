using AutoMapper;
using StudentManagingSystem.Model.Interface;
using StudentManagingSystem.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace StudentManagingSystem.Repository.IRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ISmsDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public UserRepository(ISmsDbContext context, IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<User> GetById(string id)
        {
            var User = await _userManager.FindByIdAsync(id);
            if (User == null) throw new ArgumentException("Can not find !!!");
            return User;
        }

        public async Task<List<User>> Search()
        {
            var list = await _context.Users.Where(i => i.Activated && i.Type == 1).ToListAsync();
            return list;
        }
    }
}
