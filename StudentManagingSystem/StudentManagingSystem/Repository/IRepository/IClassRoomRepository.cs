using StudentManagingSystem.Model;

namespace StudentManagingSystem.Repository.IRepository
{
    public interface IClassRoomRepository
    {
        Task Add(ClassRoom classRoom, CancellationToken cancellationToken = default);
        Task Update(ClassRoom classRoom, CancellationToken cancellationToken = default);
        Task Delete(Guid id, CancellationToken cancellationToken = default);
        Task<ClassRoom> GetById(Guid id);
        Task<List<ClassRoom>> GetAll();
        Task<List<ClassRoom>> Search();
    }
}
