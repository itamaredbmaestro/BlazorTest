using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestClasses
{
    public class Hirarchy
    {
        public Employee Emp { get; set; }

        public List<Hirarchy> Dependents { get; set; }

        public Hirarchy(Employee emp)
        {
            Emp = emp;
            Dependents = new List<Hirarchy>();
        }
    }
}
