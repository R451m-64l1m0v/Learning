using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterToDoc.BD;
using RegisterToDoc.Models;

namespace RegisterToDoc.Services
{
    public class AdminService
    {
        private readonly ApplicationDBContext _dbContext;

        public AdminService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Создание рабочего дня с часами работы
        /// </summary>
        public void InsertWorkDay(int idDoctor, int dayNumber, int from, int to)
        {
            // Вызов из BD врача и его рабочие дни по id 
            var currentDoctor = _dbContext.Doctors
                .Include(x => x.WorkGraphic)
                .FirstOrDefault(x => x.Id == idDoctor);

            //Создает рабочие часы
            var intervals = new List<Interval>();
            for (int i = from; i < to; i++)
            {
                if (i == 12)
                {
                    continue;
                }
                intervals.Add(new Interval() { StartHour = i, EndHour = i + 1});
            }

            //Добавляет рабочие часы в базу
            currentDoctor.WorkGraphic.Add(new WorkGraphic() { StartHour = from, EndHour = to, DayNumber = dayNumber, Intervals = intervals});
            _dbContext.SaveChanges();
        }


        /// <summary>
        /// Создает доктора
        /// </summary>
        /// <param name="doctor1"></param>
        public void SetDoctor(DoctorDto doctor1)
        {
            var doctor = new Doctor();
            doctor.Name = doctor1.Name;
            doctor.Surname = doctor1.Surname;
            doctor.Age = doctor1.Age;
            doctor.Specialization = doctor1.Specialization;
            doctor.Education = doctor1.Education;
            doctor.Experience = doctor1.Experience;

            _dbContext.Doctors.Add(doctor);
            _dbContext.SaveChanges();
        }
    }
}
