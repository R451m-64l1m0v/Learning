using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterToDoc.Models
{
    public class Interval : BaseEntity
    {
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        
        public WorkGraphic WorkGraphic { get; set; }
    }
}
