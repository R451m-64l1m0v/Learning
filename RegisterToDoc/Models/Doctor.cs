using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public ICollection<WorkTime> WorkTimeFull { get; set; }

        //public Dictionary<int, List<Interval>> WorkTimeGraphic { get; set; }
        public ICollection<WorkTimeGraphic> WorkTimeGraphic { get; set; }
    }

    public class WorkTimeGraphic
    {
        public int Id { get; set; }
        public int DayNumber { get; set; }
        public ICollection<Interval> Intervals { get; set; }
    }

    public class DoctorVm
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
    }
}
