using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using RegisterToDoc.Models;
using RegisterToDoc.Services;

namespace RegisterToDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        /// <summary>
        /// Добавляет рабочий день и рабочие часы доктору
        /// </summary>
        [Route("SetWorkDay")]
        [HttpPost]
        public ActionResult InsertWorkDay(int idDoctor, int number, int from, int to)
        {
            //Вызов списка врачей
            var doctors = DoctorDataService._Doctors;
            // Вызов из списка врачей врача по id
            var currentDoctor = doctors.FirstOrDefault(x => x.Id == idDoctor);

            try
            {
                if (currentDoctor.WorkTimeFull == null)
                {
                    currentDoctor.WorkTimeFull = new List<WorkTime>();
                }

                currentDoctor?.WorkTimeFull.Add(new WorkTime()
                {
                    StartHour = from,
                    EndHour = to,
                    Number = number,
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
                currentDoctor.WorkTimeGraphic.Add(number, intervals);

                return Ok("Успешно установлен рабочий день доктору");
            }
            catch (Exception e)
            {
                throw new Exception("Не удалось установить рабочий день и сгенерировать график");
            }
        }

        

        /// <summary>
        /// Добавляет доктора
        /// </summary>
        [Route("SetDoctor")]
        [HttpPost]
        public ActionResult SetDoctor(string Name, string Surname, int Age, string Specialization, string Education, int Experience)
        {
            List<Doctor> doctors = DoctorDataService._Doctors;
            
            try
            {
                //Генерирует Id для нового доктора
                int lastId = 0;
                if (doctors.Count > 0)
                {
                    lastId = doctors.Max(x => x.Id);
                }

                var doctor = new Doctor();
                // тернарный оператор if/else
                doctor.Id = lastId == 0 ? 1 : lastId + 1;
                doctor.Name = Name;
                doctor.Surname = Surname;
                doctor.Age = Age;
                doctor.Specialization = Specialization;
                doctor.Education = Education;
                doctor.Experience = Experience;

                doctors.Add(doctor);

                return Ok("Док добавлен");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка добавления доктора- {e.Message}");
            }
        }
    }
}
