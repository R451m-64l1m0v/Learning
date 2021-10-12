using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace RegisterToDoc.Models
{
    /// <summary>
    /// Доменная, т.е. лежит в БД
    /// </summary>
    public class Doctor : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }
        public string Education { get; set; }
        public int Experience { get; set; }
        public ICollection<WorkGraphic> WorkGraphic { get; set; }
        public byte[] Avatar { get; set; }

    }

    /// <summary>
    /// Приходит с фронта
    /// </summary>
    public class DoctorDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Specialization { get; set; }
        public string Education { get; set; }
        public int Experience { get; set; }        
       
    }

    /// <summary>
    /// Уходит на фронт
    /// </summary>
    public class DoctorVm
    {
        public int Id { get; set; }
        public string Specialization { get; set; }
        public int Experience { get; set; }
        public string Avatar { get; set; }
    }
}
