using System.Collections.Generic;

namespace RegisterToDoc.Models
{
    public class WorkGraphic : BaseEntity
    {
        public int DayNumber { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public ICollection<Interval> Intervals { get; set; }

        public Doctor Doctor { get; set; }
    }

    public class WorkGraphicVm
    {
        public int DayNumber { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public ICollection<Interval> Intervals { get; set; }
    }

    public class WorkGraphicDto
    {
        public int DayNumber { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
    }
}
