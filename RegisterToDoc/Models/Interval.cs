using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterToDoc.Models
{
    public class Interval
    {
        public int Id { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        
        public WorkTimeGraphic WorkTimeGraphic { get; set; }
    }
}
