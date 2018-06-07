using System;
using System.Collections.Generic;

namespace dotnet
{
    public partial class Course
    {
        public Course()
        {
            PrereqCourse = new HashSet<Prereq>();
            PrereqPrereqNavigation = new HashSet<Prereq>();
            Section = new HashSet<Section>();
        }

        public string CourseId { get; set; }
        public string Title { get; set; }
        public string DeptName { get; set; }
        public decimal? Credits { get; set; }

        public Department DeptNameNavigation { get; set; }
        public ICollection<Prereq> PrereqCourse { get; set; }
        public ICollection<Prereq> PrereqPrereqNavigation { get; set; }
        public ICollection<Section> Section { get; set; }
    }
}
