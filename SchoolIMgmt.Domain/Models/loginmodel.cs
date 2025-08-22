using System.ComponentModel.DataAnnotations;

namespace SchoolIMgmt.Models
{
    public class loginmodel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
