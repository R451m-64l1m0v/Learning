using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegisterToDoc.Models;
using RegisterToDoc.Services;

namespace RegisterToDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        /// <summary>
        /// Показыват врачей по специальности и опыту работы
        /// </summary>
        [Route("GetDoctorsByFilter")]
        [HttpGet]
        public List<Doctor> Get(string spec, int exper = 0)
        {
            var doctors = DoctorDataService._Doctors;

            return doctors.Where(x => x.Specialization == spec).Where(x => x.Experience >= exper).ToList();
        }

        /// <summary>
        /// Показыват врачей по специальности
        /// </summary>
        [Route("GetSpecs")]
        [HttpGet]
        public List<string> GetSpecs()
        {
            var doctors = DoctorDataService._Doctors;

            return doctors.Select(x => x.Specialization).Distinct().ToList();
        }

        /// <summary>
        /// Показыват рабочие дни и часы доктора
        /// </summary>
        [Route("GetReception")]
        [HttpGet]
        public Dictionary<int, List<Interval>> GetReception(int id)
        {
            var doctors = DoctorDataService._Doctors;

            var currentDoctor = doctors.FirstOrDefault(x => x.Id == id);

            if (currentDoctor != null)
            {
                return currentDoctor.WorkTimeGraphic;
            }
            else
            {
                throw new Exception($"Не найден доктор по id - {id}");
            }
        }

        /// <summary>
        /// Запись к Врачу
        /// </summary>
        [Route("Appointment")]
        [HttpPost]
        public ActionResult Appointment(int idDoctor, int number, int from, int to)
        {
            try
            {
                //Вызов списка врачей
                var doctors = DoctorDataService._Doctors;
                // Вызов из списка врачей врача по id
                var currentDoctor = doctors.FirstOrDefault(x => x.Id == idDoctor);

                var interval = currentDoctor.WorkTimeGraphic.FirstOrDefault(x => x.Key == number).Value
                    .FirstOrDefault(x => x.StartHour == from);

                if (interval != null)
                {
                    currentDoctor.WorkTimeGraphic.FirstOrDefault(x => x.Key == number).Value.Remove(interval);
                }

                return Ok("Запись прошла успешно");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка записи на прием - {e.Message}");
            }
        }
    }
}
