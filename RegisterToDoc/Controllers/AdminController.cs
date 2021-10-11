using Microsoft.AspNetCore.Mvc;
using RegisterToDoc.Models;
using RegisterToDoc.Services;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using RegisterToDoc.BD;

namespace RegisterToDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;
        private readonly IDbRepository<Doctor> doctorRepository;

        public AdminController(AdminService adminService,
            IDbRepository<Doctor> _doctorRepository)
        {
            _adminService = adminService;
            doctorRepository = _doctorRepository;
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
        [Route("SetDoctor")]
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

        /// <summary>
        /// Добавляет аватар док
        /// </summary>
        [Route("SetAvatar")]
        [HttpPost]
        public ActionResult SetAvatar(IFormFile avatar, int idDoctor)
        {
            try
            {
                var doctor = doctorRepository.GetById(idDoctor);

                if (doctor != null)
                {
                    if (avatar != null)
                    {
                        byte[] imageData = null;
                        // считываем переданный файл в массив байтов
                        using (var binaryReader = new BinaryReader(avatar.OpenReadStream()))
                        {
                            imageData = binaryReader.ReadBytes((int)avatar.Length);
                        }
                        // установка массива байтов
                        doctor.Avatar = imageData;

                        doctorRepository.Update(doctor);
                        return Ok();
                    }
                }
                return BadRequest();
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }
    }
}
