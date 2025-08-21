using System.ComponentModel.DataAnnotations;

namespace SchoolIMgmt.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }   // PK

        [Required]
        public string StudentId { get; set; } = string.Empty; // Auto generated

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Range(1, 120)]
        public int Age { get; set; }

        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }

        [Required]
        public string Gender { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, Phone]
        public string Phone { get; set; } = string.Empty;

        public ICollection<Qualification> Qualifications { get; set; } = new List<Qualification>();
    }
}
