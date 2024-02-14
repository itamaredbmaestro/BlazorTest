using BlazorTestBL;
using BlazorTestClasses;

namespace BlazorDbTable.ViewModel
{
    public class EmployeeVM
    {
        public EmployeeVM()
        {
            Employees = BlazorTestBL.BlazorTestBL.GetEmployees();
        }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
