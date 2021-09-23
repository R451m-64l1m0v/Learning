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
        private readonly ApplicationDBContext _dbContext;

        public ClientService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Doctor> GetDoctorsByFilter(string spec, int exper = 0)
        {
            return _dbContext.Doctors.Where(x => x.Specialization == spec)
                .Where(x => x.Experience >= exper).ToList();
        }

        public List<string> GetSpecs()
        {

            return _dbContext.Doctors.Select(x => x.Specialization).ToList();
        }

        public ICollection<WorkGraphic> GetReception(int id)
        {
            var currentDoctor = _dbContext.Doctors
                .Include(x => x.WorkGraphic)
                .ThenInclude(x => x.Intervals)
                .FirstOrDefault(x => x.Id == id);

            if (currentDoctor != null)
            {
                return currentDoctor.WorkGraphic;
            }
            else
            {
                throw new Exception($"Не найден доктор по id - {id}");
            }
        }

        public void Appointment(int idDoctor, int dataNumber, int from, int to)
        {
            // Вызов из DB врача по id
            var currentDoctor = _dbContext.Doctors.
                Include(x => x.WorkGraphic).
                ThenInclude(x => x.Intervals).
                FirstOrDefault(x => x.Id == idDoctor);

            var interval = currentDoctor.WorkGraphic.
                FirstOrDefault(x => x.DayNumber == dataNumber).Intervals.
                FirstOrDefault(x => x.StartHour == from);

            if (interval != null)
            {
                _dbContext.Intervals.Remove(interval);
                _dbContext.SaveChanges();
                //currentDoctor.WorkGraphic.FirstOrDefault(x => x.DayNumber == dataNumber).Intervals.interval;
            }
        }
    }
}
