﻿using Microsoft.AspNetCore.Mvc;
using RegisterToDoc.Models;
using RegisterToDoc.Services;
using System;
using Microsoft.AspNetCore.Authorization;

namespace RegisterToDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        /// <summary>
        /// Добавляет рабочий день и рабочие часы доктору
        /// </summary>
        [Route("SetWorkDay")]
        [HttpPost]
        public ActionResult InsertWorkDay(WorkGraphicDto workGraphicDto, int idDoctor  /*int idDoctor, int dayNumber, int from, int to*/)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _adminService.InsertWorkDay(workGraphicDto, idDoctor);

                    return Ok("Успешно установлен рабочий день доктору");
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                throw new Exception("Не удалось установить рабочий день и сгенерировать график");
            }
        }

        /// <summary>
        /// Добавляет доктора
        /// </summary>
        [Route("InsertDoctor")]
        [HttpPost]
        public ActionResult SetDoctor(DoctorDto doctor /*string Name, string Surname, int Age, string GetSpecialization, string Education, int Experience*/)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _adminService.InsertDoctor(doctor);

                    return Ok("Док добавлен");
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка добавления доктора- {e.Message}");
            }
        }
    }
}
