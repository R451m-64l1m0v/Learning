using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterToDoc.BD;
using RegisterToDoc.Models;

namespace RegisterToDoc.Services
{
    public class AdminService
    {
        private readonly IDbRepository<Doctor> _doctorRepository;
        private readonly IDbRepository<WorkGraphic> _wGrepository;

        public AdminService(IDbRepository<Doctor> doctorRepository, IDbRepository<WorkGraphic> wGrepository)
        {
            _doctorRepository = doctorRepository;
            _wGrepository = wGrepository;
        }
        

        /// <summary>
        /// Создание рабочего дня с часами работы
        /// </summary>
        public void InsertWorkDay(WorkGraphicDto workGraphicDto, int idDoctor)
        {
            var obedCounter = 0;
            //Создает рабочие часы
            var intervals = new List<Interval>();
            for (int i = workGraphicDto.StartHour; i < workGraphicDto.EndHour; i++)
            {
                if (obedCounter == 4)
                {
                    obedCounter = 0;
                    continue;
                }
                intervals.Add(new Interval() { StartHour = i, EndHour = i + 1 });
                obedCounter++;
            }

            //Вызов из BD врача и его рабочие дни по id  //todo:
            var currentDoctor = _doctorRepository.GetById(idDoctor);

            var workGraphics= _wGrepository.DbContext.WorkGraphics
                .Include(x=>x.Doctor)
                .Where(x => x.Doctor.Id == idDoctor);

            if (workGraphics.All(x => x.DayNumber != workGraphicDto.DayNumber))
            {
                var wG = new WorkGraphic
                {
                    Doctor = currentDoctor,
                    DayNumber = workGraphicDto.DayNumber,
                    StartHour = workGraphicDto.StartHour,
                    EndHour = workGraphicDto.EndHour,
                    Intervals = intervals
                };
                _wGrepository.Insert(wG);
            }
        }

        /// <summary>
        /// Создает доктора
        /// </summary>
        /// <param name="doctor1"></param>
        public void InsertDoctor(DoctorDto doctor1)
        {
            var doctor = new Doctor
            {
                Name = doctor1.Name,
                Surname = doctor1.Surname,
                Age = doctor1.Age,
                Specialization = doctor1.Specialization,
                Education = doctor1.Education,
                Experience = doctor1.Experience        
            };

            

            _doctorRepository.Insert(doctor); //todo:
        }

        
    }
}
