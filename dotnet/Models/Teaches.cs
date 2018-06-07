using System;
using System.Collections.Generic;

namespace dotnet
{
    public partial class Teaches
    {
        public string Id { get; set; }
        public string CourseId { get; set; }
        public string SecId { get; set; }
        public string Semester { get; set; }
        public decimal Year { get; set; }

        public Instructor IdNavigation { get; set; }
        public Section Section { get; set; }
    }
}
