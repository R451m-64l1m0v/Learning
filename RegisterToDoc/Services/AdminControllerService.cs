using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegisterToDoc.Models;

namespace RegisterToDoc.Services
{
    public class AdminControllerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDoctor"></param>
        /// <param name="dataNumber"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void InsertWorkDay(int idDoctor, int dataNumber, int from, int to)
        {
            //Вызов списка врачей
            var doctors = DoctorDataService._Doctors;
            // Вызов из списка врачей врача по id
            var currentDoctor = doctors.FirstOrDefault(x => x.Id == idDoctor);

            if (currentDoctor.WorkTimeFull == null)
            {
                currentDoctor.WorkTimeFull = new List<WorkTime>();
            }

            currentDoctor?.WorkTimeFull.Add(new WorkTime()
            {
                StartHour = from,
                EndHour = to,
                DataNumber = dataNumber,
            });

            if (currentDoctor.WorkTimeGraphic == null)
            {
                currentDoctor.WorkTimeGraphic = new Dictionary<int, List<Interval>>();
            }

            var intervals = new List<Interval>();
            for (int i = from; i < to; i++)
            {
                if (i == 12)
                {
                    continue;
                }
                intervals.Add(new Interval() { StartHour = i, EndHour = i + 1 });
            }
            currentDoctor.WorkTimeGraphic.Add(dataNumber, intervals);
        }

        public void SetDoctor(DoctorDto doctor1)
        {
            List<Doctor> doctors = DoctorDataService._Doctors;

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

            doctors.Add(doctor);
        }
    }
}
