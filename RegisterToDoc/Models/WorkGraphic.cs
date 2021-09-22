using System.Collections.Generic;

namespace RegisterToDoc.Models
{
    public class WorkGraphic
    {
        public int Id { get; set; }
        public int DayNumber { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public ICollection<Interval> Intervals { get; set; }

        public Doctor Doctor { get; set; }
    }
}
