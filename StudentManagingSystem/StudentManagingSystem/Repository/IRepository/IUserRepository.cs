using StudentManagingSystem.Model;

namespace StudentManagingSystem.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<User> GetById(string id);
        Task<List<User>> Search();
    }
}
