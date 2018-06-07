using System;
using System.Collections.Generic;

namespace dotnet
{
    public partial class Prereq
    {
        public string CourseId { get; set; }
        public string PrereqId { get; set; }

        public Course Course { get; set; }
        public Course PrereqNavigation { get; set; }
    }
}
