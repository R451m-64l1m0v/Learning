using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegisterToDoc.Attributes;
using RegisterToDoc.BD;
using RegisterToDoc.Models;

namespace RegisterToDoc.Services
{
    [RegisrationMarker]
    public class AdminService
    {
        private readonly IDbRepository<Doctor> _docRepository;
        private readonly IDbRepository<WorkGraphic> _wGrepository;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork uow, IMapper mapper)
        {
            _docRepository = uow.DbRepository<Doctor>();
            _wGrepository = uow.DbRepository<WorkGraphic>();
            _mapper = mapper;
        }
        

        /// <summary>
        /// Создание рабочего дня с часами работы
        /// </summary>
        public void InsertWorkDay(WorkGraphicDto workGraphicDto, int idDoctor)
        {
            var obedCounter = 0;
            //Создает рабочие часы
            var intervals = new List<Interval>();
            for (int i = workGraphicDto.StartHour; i < workGraphicDto.EndHour; i++)
            {
                if (obedCounter == 4)
                {
                    obedCounter = 0;
                    continue;
                }
                intervals.Add(new Interval() { StartHour = i, EndHour = i + 1 });
                obedCounter++;
            }

            //Вызов из BD врача и его рабочие дни по id  //todo:
            var currentDoctor = _docRepository.GetById(idDoctor);

            var workGraphics= _wGrepository.Entity
                .Include(x=>x.Doctor)
                .Where(x => x.Doctor.Id == idDoctor);

            if (workGraphics.All(x => x.DayNumber != workGraphicDto.DayNumber))
            {
                var wG = new WorkGraphic
                {
                    Doctor = currentDoctor,
                    DayNumber = workGraphicDto.DayNumber,
                    StartHour = workGraphicDto.StartHour,
                    EndHour = workGraphicDto.EndHour,
                    Intervals = intervals
                };
                _wGrepository.Insert(wG);
            }
        }

        /// <summary>
        /// Создает доктора
        /// </summary>
        /// <param name="doctor1"></param>
        public void InsertDoctor(DoctorDto doctor1)
        {
            var doctor = new Doctor
            {
                Name = doctor1.Name,
                Surname = doctor1.Surname,
                Age = doctor1.Age,
                Specialization = doctor1.Specialization,
                Education = doctor1.Education,
                Experience = doctor1.Experience        
            };

            

            _docRepository.Insert(doctor); //todo:
        }

        /// <summary>
        /// Добовляет аватат доктору
        /// </summary>
        public void SetAvatar(IFormFile avatar, int idDoctor)
        {
            var doctor = _docRepository.GetById(idDoctor);

            if (doctor != null)
            {
                if (avatar != null)
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)avatar.Length);
                    }
                    // установка массива байтов
                    doctor.Avatar = imageData;

                    _docRepository.Update(doctor);                    
                }
            }            
        }

        public List<DoctorVm> GetDoctors()
        {
            var map = _mapper.Map<List<Doctor>,
                List<DoctorVm>>(_docRepository.GetAll().ToList());

            return map;
        }

        public DoctorVm GetDoctorsById(int id)
        {
            var doctor = _docRepository.GetById(id);

            var map = _mapper.Map<DoctorVm>(doctor);
                

            return map;
        }

        //public void DeleteDoctor(int idDoctor)
        //{           
        //    var currentDoctor = _docRepository.Entity.
        //        Include(x => x.WorkGraphic).
        //        ThenInclude(x => x.Intervals).
        //        FirstOrDefault(x => x.Id == idDoctor);              

        //    if (currentDoctor != null)
        //    {
        //        _docRepository.Delete(currentDoctor);
        //    }
        //}
    }
}
