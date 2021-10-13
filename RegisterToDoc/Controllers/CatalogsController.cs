using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegisterToDoc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterToDoc.Controllers
{
    public class CatalogsController : ControllerBase
    {
        private readonly CatalogsService catalogsService;

        public CatalogsController(CatalogsService catalogsService)
        {
            this.catalogsService = catalogsService;
        }
        
        [Route("SetSpecialization")]
        [HttpPost]
        public ActionResult InserSpecialization(string specNane)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    catalogsService.InserSpecialization(specNane);

                    return Ok("Специальность добавлена");
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                throw new Exception($"Не удалось добавить специальность. Ошибка: {e.Message}");
            }
        }

        [Route("GetSpecializations")]
        [HttpGet]
        [AllowAnonymous]
        public List<string> GetSpecs()
        {
            try
            {
                var doctors = catalogsService.GetSpecializations();
                return doctors;
            }
            catch (Exception e)
            {
                throw new Exception($"Ошибка не найдены врачи - {e.Message}");
            }
        }

        [Route("SetDepartment")]
        [HttpPost]
        public ActionResult InserDepartment(string depNane)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    catalogsService.InserDepartment(depNane);

                    return Ok("Отделение добавлена");
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                throw new Exception($"Не удалось добавить отделение. Ошибка: {e.Message}");
            }
        }

        [Route("GetDepartments")]
        [HttpGet]
        [AllowAnonymous]
        public List<string> GetDepartments()
        {
            try
            {
                var doctors = catalogsService.GetDepartments();
                return doctors;
            }
            catch (Exception e)
            {
                throw new Exception($"Ошибка не найдены врачи - {e.Message}");
            }
        }
    }
}
