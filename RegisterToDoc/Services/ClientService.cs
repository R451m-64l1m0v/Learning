using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterToDoc.BD;
using RegisterToDoc.Models;

namespace RegisterToDoc.Services
{
    public class ClientService
    {
        private readonly IDbRepository<Doctor> _repository;

        public ClientService(IDbRepository<Doctor> repository)
        {
            _repository = repository;
        }

        public List<Doctor> GetDoctorsByFilter(string specialization, int experience)
        {
            //return _repository.GetDoctorsByFilter(specialization, experience);
            return null;
        }

        public List<string> GetSpecialization()
        {
            //return _repository.GetSpecialization();
            return null;
        }

        public ICollection<WorkGraphic> GetReception(int id)
        {
            //var d = _repository.GetDoctorById(id);

            //if (d != null)
            //{
            //    return d.WorkGraphic;
            //}
            //else
            //{
            //    throw new Exception($"Не найден доктор по id - {id}");
            //}
            return null;

        }

        public void Appointment(int idDoctor, int dataNumber, int from, int to)
        {
            // Вызов из DB врача по id
            //var currentDoctor = DbContext.Doctors.
            //    Include(x => x.WorkGraphic).
            //    ThenInclude(x => x.Intervals).
            //    FirstOrDefault(x => x.Id == idDoctor);

            //var interval = currentDoctor.WorkGraphic.
            //    FirstOrDefault(x => x.DayNumber == dataNumber).Intervals.
            //    FirstOrDefault(x => x.StartHour == from);

            //if (interval != null)
            //{
            //    DbContext.Intervals.Remove(interval);
            //    DbContext.SaveChanges();
            //    //currentDoctor.WorkGraphic.FirstOrDefault(x => x.DayNumber == dataNumber).Intervals.interval;
            //}
        }
    }
}
