using System;
using System.Collections.Generic;

namespace StudentProject.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? Course { get; set; }
        public string? Specialization { get; set; }
        public string? StudentPercentage { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
    }
}
