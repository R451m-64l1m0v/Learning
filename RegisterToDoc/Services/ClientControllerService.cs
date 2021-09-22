using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegisterToDoc.Models;

namespace RegisterToDoc.Services
{
    public class ClientControllerService
    {
        public List<Doctor> GetDoctorsByFilter(string spec, int exper = 0)
        {
            var doctors = DoctorDataService._Doctors;

            return doctors.Where(x => x.Specialization == spec).Where(x => x.Experience >= exper).ToList();
        }

        public List<string> GetSpecs()
        {
            var doctors = DoctorDataService._Doctors;

            return doctors.Select(x => x.Specialization).Distinct().ToList();
        }

        public ICollection<WorkTimeGraphic> GetReception(int id)
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

        public void Appointment(int idDoctor, int dataNumber, int from, int to)
        {
            //Вызов списка врачей
            var doctors = DoctorDataService._Doctors;
            // Вызов из списка врачей врача по id
            var currentDoctor = doctors.FirstOrDefault(x => x.Id == idDoctor);

            var interval = currentDoctor.WorkTimeGraphic.FirstOrDefault(x => x.DayNumber == dataNumber).Intervals
                .FirstOrDefault(x => x.StartHour == from);

            if (interval != null)
            {
                currentDoctor.WorkTimeGraphic.FirstOrDefault(x => x.DayNumber == dataNumber).Intervals.Remove(interval);
            }
        }
    }
}
