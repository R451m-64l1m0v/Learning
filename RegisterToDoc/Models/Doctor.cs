using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterToDoc.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }
        public string Education { get; set; }
        public int Experience { get; set; }

        public List<WorkTime> WorkTimeFull { get; set; }

        public Dictionary<int, List<Interval>> WorkTimeGraphic { get; set; }
    }
}
