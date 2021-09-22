using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterToDoc.Models
{
    public class WorkTime
    {
        public int Id { get; set; }
        public int StartHour { get; set; }
        public int EndHour { get; set; }

        public int DataNumber;

        public Doctor Doctor { get; set; }
    }
}
