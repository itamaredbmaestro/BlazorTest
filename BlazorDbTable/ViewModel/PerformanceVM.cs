using BlazorTestClasses;

namespace BlazorDbTable.ViewModel
{
    public class PerformanceVM
    {
        public List<PerformanceSequance> Performance { get; set; }

        public PerformanceVM()
        {
            Performance = new List<PerformanceSequance>();
            var emps = BlazorTestBL.BlazorTestBL.GetEmployees();
            foreach (var emp in emps)
            {
                var perf = BlazorTestBL.BlazorTestBL.GetEmployeePerformance(emp);
                var best = BlazorTestBL.BlazorTestBL.GetEmployeeBestPerformance(emp, perf);
                if (best != null)
                {
                    Performance.Add(best);
                }
            }
        }
    }
}
