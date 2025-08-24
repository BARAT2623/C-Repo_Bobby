using CollegeApp.Validators;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace CollegeApp.Models
{
    public class studentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [EmailAddress(ErrorMessage = "Enter the valid Email Address")]
        public string Email { get; set; }
        [DateCheck]
        public DateTime AdmissionDate { get; set; }

    }
}
