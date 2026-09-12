using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCDemoD04.Models
{
    public class Employee
    {
        /*------------------------------------------------------------------*/
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string? Name { get; set; }

        [Required]
        [Range(18, 50)]
        public int Age { get; set; }

        [Required]
        [Range(2000,5000)]
        public decimal Salary { get; set; }

        [StringLength(256, MinimumLength = 12)]
        public string? Address { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string? Password { get; set; }

        [Compare("Password")]
        public string? ConfirmPassword { get; set; }
        /*------------------------------------------------------------------*/
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        /*------------------------------------------------------------------*/
    }
}