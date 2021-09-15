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
    public class DoctorController : ControllerBase
    {
        [Route("GetDoctorsByFilter")]
        [HttpGet]
        public List<Doctor> Get(string spec, int exper = 0)
        {
            var doctorDataService = new DoctorDataService();
            var doctors = doctorDataService.GetDoctorsList();

            return doctors.Where(x => x.Specialization == spec).Where(x => x.Experience >= exper).ToList();
        }

        [Route("GetSpecs")]
        [HttpGet]
        public List<string> GetSpecs()
        {
            var doctorDataService = new DoctorDataService();
            var doctors = doctorDataService.GetDoctorsList();

            return doctors.Select(x => x.Specialization).Distinct().ToList();
        }
    }
}
