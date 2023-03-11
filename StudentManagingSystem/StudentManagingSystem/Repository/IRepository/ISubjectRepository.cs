using StudentManagingSystem.Model;

namespace StudentManagingSystem.Repository.IRepository
{
    public interface ISubjectRepository
    {
        Task Add(Subject subject, CancellationToken cancellationToken = default);
        Task Update(Subject subject, CancellationToken cancellationToken = default);
        Task Delete(Guid id, CancellationToken cancellationToken = default);
        Task<Subject> GetById(Guid id);
        Task<List<Subject>> GetAll();
        Task<List<Subject>> Search();
    }
}
