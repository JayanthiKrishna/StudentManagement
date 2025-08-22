using SchoolIMgmt.Domain.Entities;

namespace SchoolIMgmt.Interfaces
{
    public interface IQualificationService
    {
        Task<IEnumerable<Qualification>> GetAllQAsync();
        Task<Qualification?> GetByIdQAsync(int id);
        Task AddQAsync(Qualification student);
        Task UpdateQAsync(Qualification student);
        Task DeleteQAsync(int id);
    }
}
