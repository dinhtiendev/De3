using System;
using System.Collections.Generic;

#nullable disable

namespace Q3.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Sex { get; set; }
        public string Position { get; set; }
        public int? Department { get; set; }

        public virtual Department DepartmentNavigation { get; set; }
    }
}
