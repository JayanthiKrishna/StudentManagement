using Microsoft.EntityFrameworkCore;
using SchoolIMgmt.Domain.Entities;

namespace SchoolIMgmt.Repositories
{
    public class StudentRepository: IStudentRepository
    {
        private readonly AppDbContext _context;
        public StudentRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Student>> GetAllAsync() =>
            await _context.Students.Include(s => s.Qualifications).ToListAsync();

        public async Task<Student?> GetByIdAsync(int id) =>
            await _context.Students.Include(s => s.Qualifications)
                                   .FirstOrDefaultAsync(s => s.Id == id);

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }


    }
}
