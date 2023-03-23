using StudentManagingSystem.Model;

namespace StudentManagingSystem.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<List<AppUser>> GetAll();
        Task<AppUser> GetById(string id);
        Task<List<AppUser>> Search();
    }
}
