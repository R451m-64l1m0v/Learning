using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterToDoc.BD;
using RegisterToDoc.Models;

namespace RegisterToDoc.Services
{
    public class ClientService
    {
        private readonly IDbRepository<Doctor> _docRepository;
        private readonly IDbRepository<WorkGraphic> _wgRepository;
        

        public ClientService(IDbRepository<Doctor> docRepository , IDbRepository<WorkGraphic> wgRepository)
        {
            _docRepository = docRepository;
            _wgRepository = wgRepository;
        }

        public List<Doctor> GetDoctorsByFilter(string specialization, int experience)
        {
            return _docRepository.GetAll().Where(x => x.Specialization == specialization)
                .Where(x => x.Experience >= experience).ToList();
        }

        public List<string> GetSpecialization()
        {
            return _docRepository.GetAll().Select(x => x.Specialization).ToList();
        }

        public IEnumerable<WorkGraphic> GetReception(int id)
        {
            var d = _wgRepository.GetAll().Where(x=>x.Doctor.Id == id);

            return d;
            
        }

        public void Appointment(int idDoctor, int dataNumber, int from, int to)
        {
            //Вызов из DB врача по id
            var currentDoctor = _docRepository.DbContext.Doctors.
                Include(x => x.WorkGraphic).
                ThenInclude(x => x.Intervals).
                FirstOrDefault(x => x.Id == idDoctor);

            if (currentDoctor != null)
            {
                var interval = currentDoctor.WorkGraphic.
                    FirstOrDefault(x => x.DayNumber == dataNumber).Intervals.
                    FirstOrDefault(x => x.StartHour == from);

                if (interval != null)
                {
                    _docRepository.DbContext.Intervals.Remove(interval);
                    _docRepository.DbContext.SaveChanges();
                }
                else
                {
                    throw new Exception("Не удалось записаться");
                }
            }
            else
            {
                throw new Exception("Не удалось записаться");
            }
        }
    }
}
