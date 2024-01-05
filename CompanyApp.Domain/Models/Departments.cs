using CompanyApp.Domain.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Models
{
    public class Department : BaseEntity
    {
        public Department()
        {
            Employees = new();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public List<Employee> Employees { get; set; }


        public override string ToString()
        {
            return $"Name:{Name}  Capacity:{Capacity}/{Employees.Count}";
        }
    }

}
