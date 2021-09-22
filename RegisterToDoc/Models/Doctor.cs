using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegisterToDoc.Models
{
    public class Doctor : DoctorDto
    {
        public int Id { get; set; }
        public ICollection<WorkGraphic> WorkGraphic { get; set; }
    }

    public class DoctorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }
        public string Education { get; set; }
        public int Experience { get; set; }
    }

    public class DoctorVm
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
    }
}
