using System.ComponentModel;

namespace MVCDemoD04.Models
{
    public class Employee
    {
        /*------------------------------------------------------------------*/
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        /*------------------------------------------------------------------*/
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        /*------------------------------------------------------------------*/
    }
}