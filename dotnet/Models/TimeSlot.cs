using System;
using System.Collections.Generic;

namespace dotnet
{
    public partial class TimeSlot
    {
        public string TimeSlotId { get; set; }
        public string Day { get; set; }
        public decimal StartHr { get; set; }
        public decimal StartMin { get; set; }
        public decimal? EndHr { get; set; }
        public decimal? EndMin { get; set; }
    }
}
