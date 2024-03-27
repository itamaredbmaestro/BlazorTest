using BlazorTestClasses;

namespace BlazorDbTable.ViewModel
{
    public class DuplicatesVM
    {
        public DuplicatesVM()
        {
            Employees = BlazorTestBL.BlazorTestBL.DuplicateManagerEmployees(BlazorTestBL.BlazorTestBL.GetEmployeeHirarchy());
            if (Employees == null)
                Employees = new List<Employee>();
        }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
