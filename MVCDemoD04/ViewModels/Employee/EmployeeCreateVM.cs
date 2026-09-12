using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace MVCDemoD04.ViewModels.Employee
{
    public class EmployeeCreateVM
    {
        #region Get From Form
        public string? Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        #endregion

        #region Sent To Form
        public List<SelectListItem>? Departments { get; set; }
        #endregion
    }
}