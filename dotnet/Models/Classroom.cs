using System;
using System.Collections.Generic;

namespace dotnet
{
    public partial class Classroom
    {
        public Classroom()
        {
            Section = new HashSet<Section>();
        }

        public string Building { get; set; }
        public string RoomNumber { get; set; }
        public decimal? Capacity { get; set; }

        public ICollection<Section> Section { get; set; }
    }
}
