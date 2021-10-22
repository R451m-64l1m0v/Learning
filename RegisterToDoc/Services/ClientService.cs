using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterToDoc.Attributes;
using RegisterToDoc.BD;
using RegisterToDoc.Models;

namespace RegisterToDoc.Services
{   
    [RegisrationMarker]
    public class ClientService
    {
        private readonly IDbRepository<Doctor> _docRepository;
        private readonly IDbRepository<WorkGraphic> _wGrepository;
        private readonly IDbRepository<Interval> intervalRepository;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork uow, IMapper mapper)
        {
            _docRepository = uow.DbRepository<Doctor>();
            _wGrepository = uow.DbRepository<WorkGraphic>();
            intervalRepository = uow.DbRepository<Interval>();
            _mapper = mapper;
        }

        public List<DoctorVm> GetDoctorsByFilter(string specialization, int experience)
        {
            var mapSpecExper = _mapper.Map<IEnumerable<Doctor>,
                List<DoctorVm>>(_docRepository.GetAll()).Where(x => x.Experience >= experience).
                Where(x => x.Specialization == specialization).ToList();

            return mapSpecExper;
        }

        public List<string> GetSpecialization()
        {
            var mapSpec = _mapper.Map<IEnumerable<Doctor>,
                List<DoctorVm>>(_docRepository.GetAll()).Select(x => x.Specialization).ToList();

            return mapSpec;
        }

        public IEnumerable<WorkGraphicVm> GetReception(int id)
        {
            var workGraphicsDoc = _wGrepository.Entity.
                Include(x => x.Doctor).
                Include(x => x.Intervals).
                Where(x => x.Doctor.Id == id).ToList();

            var lst = new List<WorkGraphicVm>();

            foreach (var workGraphic in workGraphicsDoc)
            {
                var intervals = new List<Interval>();

                foreach (var interval in workGraphic.Intervals)
                {
                    intervals.Add(new Interval()
                    {
                        Id = interval.Id,
                        EndHour = interval.EndHour,
                        StartHour = interval.StartHour,
                    });
                }

                var model = new WorkGraphicVm()
                {
                    EndHour = workGraphic.EndHour,
                    StartHour = workGraphic.StartHour,
                    Intervals = intervals,
                    DayNumber = workGraphic.DayNumber
                };

                lst.Add(model);
            }

            return lst;
        }

        /// <summary>
        /// Запись к врачу
        /// </summary>
        /// <param name="workGraphicDto"></param>
        /// <param name="idDoctor"></param>
        public void Appointment(WorkGraphicDto workGraphicDto, int idDoctor)
        {
            var currentDoctor = _docRepository.Entity.
                Include(x => x.WorkGraphic).
                ThenInclude(x => x.Intervals).
                FirstOrDefault(x => x.Id == idDoctor);

            if (currentDoctor != null)
            {
                var interval = currentDoctor.WorkGraphic
                    .FirstOrDefault(x => x.DayNumber == workGraphicDto.DayNumber)
                    .Intervals
                    .FirstOrDefault(x => x.StartHour == workGraphicDto.StartHour);

                if (interval.Busy != true)
                {
                    interval.Busy = true;
                    intervalRepository.Update(interval);
                }
                else
                {
                    throw new Exception("Не удалось записаться, данное время занято");
                }
            }
            else
            {
                throw new Exception("Не удалось записаться, не найден доктор");
            }
        }

        /// <summary>
        /// Отмена записи к врачу
        /// </summary>
        /// <param name="workGraphicDto"></param>
        /// <param name="idDoctor"></param>
        public void CancelRecording(WorkGraphicDto workGraphicDto, int idDoctor)
        {
            var currentDoctor = _docRepository.Entity.
               Include(x => x.WorkGraphic).
               ThenInclude(x => x.Intervals).
               FirstOrDefault(x => x.Id == idDoctor);

            var interval = currentDoctor.WorkGraphic
                   .FirstOrDefault(x => x.DayNumber == workGraphicDto.DayNumber)
                   .Intervals
                   .FirstOrDefault(x => x.StartHour == workGraphicDto.StartHour);


            if (currentDoctor != null)
            {

                if (interval.Busy != false)
                {
                    interval.Busy = false;
                    intervalRepository.Update(interval);
                }
                else
                {
                    throw new Exception("Не удалось отменить запись");
                }
            }
            else
            {
                throw new Exception("Не удалось отменить запись, не найден доктор");
            }
        }
    }
}
