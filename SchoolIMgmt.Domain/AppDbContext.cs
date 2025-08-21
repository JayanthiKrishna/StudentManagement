using Microsoft.EntityFrameworkCore;
using SchoolIMgmt.Domain.Entities;

namespace SchoolIMgmt
{
    
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Student> Students { get; set; }
            public DbSet<Qualification> Qualifications { get; set; }
        }

    
}
