using StudentManagingSystem.Model;
using StudentManagingSystem.Utility;

namespace StudentManagingSystem.Repository.IRepository
{
    public interface INotiRepository
    {
        Task Add(Notification noti, CancellationToken cancellationToken = default);
        Task Update(Notification noti, CancellationToken cancellationToken = default);
        Task Delete(Guid id, CancellationToken cancellationToken = default);
        Task<Notification> GetById(Guid id);
        Task<List<Notification>> GetAll();
        Task<PagedList<Notification>> Search(int page, int pagesize);
    }
}
