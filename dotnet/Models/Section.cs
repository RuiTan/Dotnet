using System;
using System.Collections.Generic;

namespace dotnet
{
    public partial class Section
    {
        public Section()
        {
            Takes = new HashSet<Takes>();
            Teaches = new HashSet<Teaches>();
        }

        public string CourseId { get; set; }
        public string SecId { get; set; }
        public string Semester { get; set; }
        public decimal Year { get; set; }
        public string Building { get; set; }
        public string RoomNumber { get; set; }
        public string TimeSlotId { get; set; }

        public Classroom Classroom { get; set; }
        public Course Course { get; set; }
        public ICollection<Takes> Takes { get; set; }
        public ICollection<Teaches> Teaches { get; set; }
    }
}
