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

        public static PerformanceSequance GetEmployeeBestPerformance(Employee employee)
        {
            return null;
        }

        public static PerformanceSequance GetBestEmployeePerformance()
        {
            return null;
        }

        public static IEnumerable<string> CreateEmployeeEmail(Employee employee)
        {
            return EMailGenerator.CreatePerformanceEmail(employee, GetEmployeePerformance(employee), GetEmployeeBestPerformance(employee));
        }

        public static IEnumerable<string> CreateBestEmployeeEmail()
        {
            return EMailGenerator.CreateBestPerformanceEmail(GetBestEmployeePerformance());
        }
    }
}