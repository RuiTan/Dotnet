using System;
using System.Collections.Generic;

namespace dotnet
{
    public partial class Department
    {
        public Department()
        {
            Course = new HashSet<Course>();
            Instructor = new HashSet<Instructor>();
            Student = new HashSet<Student>();
        }

        public string DeptName { get; set; }
        public string Building { get; set; }
        public decimal? Budget { get; set; }

        public ICollection<Course> Course { get; set; }
        public ICollection<Instructor> Instructor { get; set; }
        public ICollection<Student> Student { get; set; }
    }
}
