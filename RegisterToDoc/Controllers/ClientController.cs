﻿using System;
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
        ClientControllerService _clientControllerService;

        public ClientController(ClientControllerService clientControllerClientControllerService)
        {
            _clientControllerService = clientControllerClientControllerService;
        }

        /// <summary>
        /// Показыват врачей по специальности и опыту работы
        /// </summary>
        [Route("GetDoctorsByFilter")]
        [HttpGet]
        public List<DoctorVm> Get(string spec, int exper = 0)
        {
            try
            {
                var doctors = _clientControllerService.Get(spec, exper);
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
                var doctors = _clientControllerService.GetSpecs();
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
        public Dictionary<int, List<Interval>> GetReception(int id)
        {
            try
            {
                var currentDoctor = _clientControllerService.GetReception(id);
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
                _clientControllerService.Appointment(idDoctor, dataNumber, from, to);

                return Ok("Запись прошла успешно");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка записи на прием - {e.Message}");
            }
        }
    }
}
