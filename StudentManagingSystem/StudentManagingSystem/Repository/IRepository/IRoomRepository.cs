using StudentManagingSystem.Model;
using StudentManagingSystem.Utility;

namespace StudentManagingSystem.Repository.IRepository
{
    public interface IRoomRepository
    {
        Task Add(ClassRoom classRoom, CancellationToken cancellationToken = default);
        Task Update(ClassRoom classRoom, CancellationToken cancellationToken = default);
        Task Delete(Guid id, CancellationToken cancellationToken = default);
        Task<ClassRoom> GetById(Guid id);
        Task<List<ClassRoom>> GetAll();
        Task<PagedList<ClassRoom>> Search(string? keyword, bool? status, int page, int pagesize);
    }
}
