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
        AdminControllerService service = new ();
        /// <summary>
        /// Добавляет рабочий день и рабочие часы доктору
        /// </summary>
        [Route("SetWorkDay")]
        [HttpPost]
        public ActionResult InsertWorkDay(int idDoctor, int dataNumber, int from, int to)
        {
            try
            {
                service.InsertWorkDay(idDoctor, dataNumber, from, to);

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
            try
            {
                service.SetDoctor(Name, Surname, Age, Specialization, Education, Experience);

                return Ok("Док добавлен");
            }
            catch (Exception e)
            {
                return BadRequest($"Ошибка добавления доктора- {e.Message}");
            }
        }
    }
}
