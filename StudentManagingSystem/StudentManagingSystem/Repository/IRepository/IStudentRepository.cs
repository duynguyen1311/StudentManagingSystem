using StudentManagingSystem.Model;

namespace StudentManagingSystem.Repository.IRepository
{
    public interface IStudentRepository
    {
        Task Add(Student student, CancellationToken cancellationToken = default);
        Task Update(Student student, CancellationToken cancellationToken = default);
        Task Delete(Guid id, CancellationToken cancellationToken = default);
        Task<Student> GetById(Guid id);
        Task<List<Student>> GetAll();
    }
}
