using System;
using System.Collections.Generic;

namespace dotnet
{
    public partial class Advisor
    {
        public string SId { get; set; }
        public string IId { get; set; }

        public Instructor I { get; set; }
        public Student S { get; set; }
    }
}
