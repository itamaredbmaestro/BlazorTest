using BlazorTestClasses;
using BlazorTestDal;
using BlazorTestEmailTemplates;
using System.Collections.Generic;

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
            if (performance.Any())
            {
                var list = performance.ToList();
                List<int> values = list.Select(p => p.TicketsOverMin).ToList();
                if (values.Any())
                {
                    GetMaxSum(values, out int fromIndex, out int toIndex, out int total);
                    if (fromIndex >= 0)
                    {
                        return new PerformanceSequance()
                        {
                            Emp = employee,
                            FromDay = list[fromIndex].Day,
                            ToDay = list[toIndex].Day,
                            Month = list[toIndex].Month,
                            SumTicketsOverMin = total
                        };
                    }
                }
            }
            return null;
        }

        public static void GetMaxSum(List<int> values, out int fromIndex, out int toIndex, out int total)
        {
            // Fill this function as an answer for question 1
            // The code here is for compilation reasons, feel free to delete it if needed
            fromIndex = -1;
            toIndex = -1;
            total = -1;
        }

        public static IEnumerable<string> CreateEmployeeEmail(Employee employee)
        {
            var performance = GetEmployeePerformance(employee);
            return EMailGenerator.CreatePerformanceEmail(employee, performance, GetEmployeeBestPerformance(employee, performance));
        }

        public static IEnumerable<Employee> DuplicateManagerEmployees(Hirarchy hirarchy)
        {
            return null;
        }
    }
}
