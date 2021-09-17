using Microsoft.AspNetCore.Mvc;
using RegisterToDoc.Models;
using RegisterToDoc.Services;
using System;

namespace RegisterToDoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminControllerService _adminControllerService;

        public AdminController(AdminControllerService adminControllerService)
        {
            _adminControllerService = adminControllerService;
        }

        /// <summary>
        /// Добавляет рабочий день и рабочие часы доктору
        /// </summary>
        [Route("SetWorkDay")]
        [HttpPost]
        public ActionResult InsertWorkDay(int idDoctor, int dataNumber, int from, int to)
        {
            try
            {
                _adminControllerService.InsertWorkDay(idDoctor, dataNumber, from, to);

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
        public ActionResult SetDoctor(DoctorDto doctor /*string Name, string Surname, int Age, string Specialization, string Education, int Experience*/)
        {
            try
            {
                _adminControllerService.SetDoctor(doctor);

                return Ok("Док добавлен");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка добавления доктора- {e.Message}");
            }
        }
    }
}
