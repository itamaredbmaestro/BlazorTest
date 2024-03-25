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

        public static Hirarchy GetHierarchy()
        {
            List<Tuple<int, int>> data = new List<Tuple<int, int>>();
            var reader = CsvDataReader.Create(Path.Combine(Path.GetDirectoryName(typeof(BlazorTestDal).Assembly.Location), "Data", "Hirarchy.csv"));
            while (reader.Read())
            {
                data.Add(new Tuple<int, int>(reader.GetInt32(0), reader.GetInt32(1)));
            }
            var employees = GetEmployees().ToList();
            return ParseHirarchy(data, employees, 30);
        }

        private static Hirarchy ParseHirarchy(List<Tuple<int, int>> data, List<Employee> employees, int parent)
        {
            var hierarchy = new Hirarchy(employees.Single(e => e.ID == parent));
            foreach (var item in data.Where(d => d.Item2 == parent))
            {
                hierarchy.Dependents.Add(ParseHirarchy(data, employees, item.Item1));
            }
            return hierarchy;
        }
    }
}