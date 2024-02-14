using BlazorTestClasses;
using Sylvan.Data.Csv;

namespace BlazorTestDal
{
    public static class BlazorTestDal
    {
        public static IEnumerable<Employee> GetEmployees()
        {
            var reader = CsvDataReader.Create(Path.Combine(Path.GetDirectoryName(typeof(BlazorTestDal).Assembly.Location), "Data", "Employees.csv"));
            while (reader.Read())
            {
                yield return new Employee()
                {
                    ID = reader.GetInt32(0),
                    FName = reader.GetString(1),
                    LName = reader.GetString(2),
                    EMail = reader.GetString(3)
                };
            }
        }

        public static IEnumerable<Performance> GetEmployeePerformance()
        {
            var reader = CsvDataReader.Create(Path.Combine(Path.GetDirectoryName(typeof(BlazorTestDal).Assembly.Location), "Data", "Performance.csv"));
            while (reader.Read())
            {
                yield return new Performance()
                {
                    EmpID = reader.GetInt32(0),
                    Month = reader.GetInt32(1),
                    Day = reader.GetInt32(2),
                    TicketsOverMin = reader.GetInt32(3)
                };
            }
        }
    }
}