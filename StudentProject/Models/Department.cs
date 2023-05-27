using System;
using System.Collections.Generic;

namespace StudentProject.Models
{
    public partial class Department
    {
        public Department()
        {
            Students = new HashSet<Student>();
        }

        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
