using Microsoft.EntityFrameworkCore;
using SchoolIMgmt.Domain.Entities;

namespace SchoolIMgmt.Repositories
{
    public class QualificationRepo:IQualificationRepo
    {

        private readonly AppDbContext _context;
        public QualificationRepo(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Qualification>> GetAllQAsync() =>
         await _context.Qualifications.ToListAsync();
        public async Task<Qualification?> GetByIdQAsync(int id) =>
            await _context.Qualifications.FirstOrDefaultAsync(s => s.Id == id);

        public async Task AddQAsync(Qualification student)
        {
            await _context.Qualifications.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateQAsync(Qualification student)
        {
            _context.Qualifications.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQAsync(int id)
        {
            var student = await _context.Qualifications.FindAsync(id);
            if (student != null)
            {
                _context.Qualifications.Remove(student);
                await _context.SaveChangesAsync();
            }
        }
    }
}
