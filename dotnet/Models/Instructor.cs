using System;
using System.Collections.Generic;

namespace dotnet
{
    public partial class Instructor
    {
        public Instructor()
        {
            Advisor = new HashSet<Advisor>();
            Teaches = new HashSet<Teaches>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string DeptName { get; set; }
        public decimal? Salary { get; set; }

        public Department DeptNameNavigation { get; set; }
        public ICollection<Advisor> Advisor { get; set; }
        public ICollection<Teaches> Teaches { get; set; }
    }
}
