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
            var doctors = DoctorDataService.Doctors;

            return doctors.Where(x => x.Specialization == spec).Where(x => x.Experience >= exper).ToList();
        }

        [Route("GetSpecs")]
        [HttpGet]
        public List<string> GetSpecs()
        {
            var doctors = DoctorDataService.Doctors;

            return doctors.Select(x => x.Specialization).Distinct().ToList();
        }

        [Route("GetReception")]
        [HttpGet]
        public Dictionary<int, List<Interval>> GetReception(int id)
        {
            var doctors = DoctorDataService.Doctors;

            var currentDoctor = doctors.FirstOrDefault(x => x.Id == id);

            if (currentDoctor != null)
            {
                if (currentDoctor.WorkTimeSvobodno == null)
                {
                    currentDoctor.WorkTimeSvobodno = new Dictionary<int, List<Interval>>();
                }

                if (currentDoctor.WorkTimeFull.Count != currentDoctor.WorkTimeSvobodno.Count)
                {
                    foreach (var workTime in currentDoctor.WorkTimeFull)
                    {
                        var svob = currentDoctor.WorkTimeSvobodno.ContainsKey(workTime.Number);
                        if (!svob)
                        {
                            var intervals = new List<Interval>();
                            for (int i = workTime.StartHour; i < workTime.EndHour; i++)
                            {
                                if (i == 12)
                                {
                                    continue;
                                }
                                intervals.Add(new Interval() { StartHour = i, EndHour = i + 1 });
                            }
                            currentDoctor.WorkTimeSvobodno.Add(workTime.Number, intervals);
                        }
                    }
                }

                return currentDoctor.WorkTimeSvobodno;
            }
            else
            {
                throw new Exception($"Не найден доктор по id - {id}");
            }


            //var releaseReceptionService = new ReleaseReceptionService();
            //var doctors = releaseReceptionService.GetReleaseReception();
        }

        [Route("SetWorkDay")]
        [HttpPost]
        public void InsertWorkDay(int idDoctor, int number, int from, int to)
        {
            var doctors = DoctorDataService.Doctors;

            var currentDoctor = doctors.FirstOrDefault(x => x.Id == idDoctor);

            currentDoctor?.WorkTimeFull.Add(new WorkTime()
            {
                StartHour = from,
                EndHour = to,
                Number = number,
            });
        }


        [Route("appointment")]
        [HttpPost]
        public void Appointment(int idDoctor, int number, int from, int to)
        {
            var doctors = DoctorDataService.Doctors;

            var currentDoctor = doctors.FirstOrDefault(x => x.Id == idDoctor);

            var interval =  currentDoctor.WorkTimeSvobodno.FirstOrDefault(x => x.Key == number).Value
                .FirstOrDefault(x => x.StartHour == from);

            if (interval != null)
            {
                currentDoctor.WorkTimeSvobodno.FirstOrDefault(x => x.Key == number).Value.Remove(interval);
            }
        }
    }
}
