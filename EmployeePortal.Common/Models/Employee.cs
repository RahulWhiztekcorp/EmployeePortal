using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeePortal.Common.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public long PhoneNo { get; set; }
        public long AadharNo { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }

        public int Department_Id { get; set; }
    }
}
