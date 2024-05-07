using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNetCommandApp
{
    internal class Teacher
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; } = "";
        public int DepartmentId { get; set; }
        public int Salary { get; set; }
    }
    
}
