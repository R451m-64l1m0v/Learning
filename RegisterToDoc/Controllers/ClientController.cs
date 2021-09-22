using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegisterToDoc.BD;
using RegisterToDoc.Models;
using RegisterToDoc.Services;

namespace RegisterToDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        ClientService _clientService;
        private readonly ApplicationDBContext _applicationDbContext;


        public ClientController(ClientService clientClientService, ApplicationDBContext applicationDbContext)
        {
            _clientService = clientClientService;
            _applicationDbContext = applicationDbContext;
        }


        /// <summary>
        /// Показыват врачей по специальности и опыту работы
        /// </summary>
        [Route("GetDoctorsByFilter")]
        [HttpGet]
        public List<DoctorVm> GetDoctorsByFilter(string spec, int exper = 0)
        {
            try
            {
                //var doctors = _clientService.GetDoctorsByFilter(spec, exper);
                var doctors = _applicationDbContext.Doctors.Where(x => x.Specialization == spec)
                    .Where(x => x.Experience >= exper).ToList();
                var doctorsVm = new List<DoctorVm>();

                foreach (var doctor in doctors)
                {
                    var doctorVm = new DoctorVm()
                    {
                        Id = doctor.Id,
                        Specialization = doctor.Specialization
                    };
                    doctorsVm.Add(doctorVm);
                }

                return doctorsVm;
            }
            catch (Exception e)
            {
                throw new Exception($"Ошибка добавления доктора- {e.Message}");
            }
        }

        /// <summary>
        /// Показыват врачей по специальности
        /// </summary>
        [Route("GetSpecs")]
        [HttpGet]
        public List<string> GetSpecs()
        {
            try
            {
                var doctors = _clientService.GetSpecs();
                return doctors;
            }
            catch (Exception e)
            {
                throw new Exception($"Ошибка не найдены врачи - {e.Message}");
            }
        }

        /// <summary>
        /// Показыват рабочие дни и часы доктора
        /// </summary>
        [Route("GetReception")]
        [HttpGet]
        public ICollection<WorkGraphic> GetReception(int id)
        {
            try
            {
                var currentDoctor = _clientService.GetReception(id);
                return currentDoctor;
            }
            catch (Exception e)
            {
                throw new Exception($"Не найден доктор по id - {id}");
            }
        }

        /// <summary>
        /// Запись к Врачу
        /// </summary>
        [Route("Appointment")]
        [HttpPost]
        public ActionResult Appointment(int idDoctor, int dataNumber, int from, int to)
        {
            try
            {
                _clientService.Appointment(idDoctor, dataNumber, from, to);

                return Ok("Запись прошла успешно");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка записи на прием - {e.Message}");
            }
        }
    }
}
