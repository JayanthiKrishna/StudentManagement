using SchoolIMgmt.Domain.Entities;
using SchoolIMgmt.Interfaces;
using SchoolIMgmt.Repositories;

namespace SchoolIMgmt.Services
{
    public class QualificationService : IQualificationService
    {
        private readonly IQualificationRepo _repo;

        public QualificationService(IQualificationRepo repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Qualification>> GetAllQAsync() => _repo.GetAllQAsync();
        public Task<Qualification?> GetByIdQAsync(int id) => _repo.GetByIdQAsync(id);

        public async Task AddQAsync(Qualification qualification)
        {
            await _repo.AddQAsync(qualification);
        }

        public Task UpdateQAsync(Qualification qualification) => _repo.UpdateQAsync(qualification);
        public Task DeleteQAsync(int id) => _repo.DeleteQAsync(id);
    }
}
