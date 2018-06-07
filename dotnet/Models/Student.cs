using System;
using System.Collections.Generic;

namespace dotnet
{
    public partial class Student
    {
        public Student()
        {
            Takes = new HashSet<Takes>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string DeptName { get; set; }
        public decimal? TotCred { get; set; }

        public Department DeptNameNavigation { get; set; }
        public Advisor Advisor { get; set; }
        public ICollection<Takes> Takes { get; set; }
    }
}
