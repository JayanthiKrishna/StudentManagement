using SchoolIMgmt.Domain.Entities;
using SchoolIMgmt.Interfaces;
using SchoolIMgmt.Repositories;

namespace SchoolIMgmt.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;

        public StudentService(IStudentRepository repo) => _repo = repo;

        public Task<IEnumerable<Student>> GetAllAsync() => _repo.GetAllAsync();
        public Task<Student?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public async Task AddAsync(Student student)
        {
            // Generate StudentId like STU00001
            student.StudentId = $"STU{DateTime.Now.Ticks.ToString().Substring(10)}";
            await _repo.AddAsync(student);
        }

        public Task UpdateAsync(Student student) => _repo.UpdateAsync(student);
        public Task DeleteAsync(int id) => _repo.DeleteAsync(id);

    }
}
