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
        public void InsertWorkDay(int idDoctor, int dataNumber, int from, int to)
        {
            // Вызов из BD врача и его рабочие дни по id 
            var currentDoctor = _dbContext.Doctors
                .Include(x => x.WorkTimeFull)
                .Include(x => x.WorkTimeGraphic)
                .FirstOrDefault(x => x.Id == idDoctor);
            currentDoctor.WorkTimeFull.Add(new WorkTime() { StartHour = from, EndHour = to, DataNumber = dataNumber });

            //Добавление робочего дня и часов выбранному доктору
            //_dbContext.WorkTimeFull.Add(new WorkTime() {StartHour = from, EndHour = to, DataNumber = dataNumber});
           //Сщхранеие в BD
            //_dbContext.SaveChanges();
            
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
            //_dbContext.WorkTimeGraphics.Add(new WorkTimeGraphic() {DayNumber = dataNumber, Intervals = intervals, Doctor = currentDoctor});
            currentDoctor.WorkTimeGraphic.Add(new WorkTimeGraphic() { DayNumber = dataNumber, Intervals = intervals});
            _dbContext.SaveChanges();
        }


        /// <summary>
        /// Создает доктора
        /// </summary>
        /// <param name="doctor1"></param>
        public void SetDoctor(DoctorDto doctor1)
        {
            var doctors = _dbContext.Doctors.ToList();

            //Генерирует Id для нового доктора
            int lastId = 0;
            if (doctors.Count > 0)
            {
                lastId = doctors.Max(x => x.Id);
            }

            var doctor = new Doctor();
            // тернарный оператор if/else
            doctor.Id = lastId == 0 ? 1 : lastId + 1;
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
