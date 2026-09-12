using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCDemoD03.ViewModels.Employee
{
    public class EmployeeCreateVM
    {
        #region Get From Form
        public string? Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentId { get; set; }
        #endregion

        #region Sent To Form
        public List<SelectListItem>? Departments { get; set; }
        #endregion
    }
}