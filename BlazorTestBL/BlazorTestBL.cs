using BlazorTestClasses;
using BlazorTestDal;
using BlazorTestEmailTemplates;

namespace BlazorTestBL
{
    public static class BlazorTestBL
    {
        public static IEnumerable<Employee> GetEmployees()
        {
            return BlazorTestDal.BlazorTestDal.GetEmployees();
        }

        public static IEnumerable<Performance> GetEmployeePerformance(Employee employee)
        {
            return BlazorTestDal.BlazorTestDal.GetEmployeePerformance().Where(p => p.EmpID == employee.ID);
        }

        public static Hirarchy GetEmployeeHirarchy()
        {
            return BlazorTestDal.BlazorTestDal.GetHierarchy();
        }

        public static PerformanceSequance GetEmployeeBestPerformance(Employee employee, IEnumerable<Performance> performance)
        {
            // Fill this function as an answer for question 2
            return null;
        }

        public static IEnumerable<string> CreateEmployeeEmail(Employee employee)
        {
            var performance = GetEmployeePerformance(employee);
            return EMailGenerator.CreatePerformanceEmail(employee, performance, GetEmployeeBestPerformance(employee, performance));
        }

        public static IEnumerable<Employee> DuplicateManagerEmployees()
        {
            Hirarchy hirarchy = GetEmployeeHirarchy();
            return null;
        }
    }
}