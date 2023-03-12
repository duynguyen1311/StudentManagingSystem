using StudentManagingSystem.Model;

namespace StudentManagingSystem.Repository.IRepository
{
    public interface IUserRepository
    {
        Task<Department> GetById(Guid id);
        Task<List<Department>> GetAll();
        Task<List<Department>> Search();
    }
}
