using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterToDoc.Models;

namespace RegisterToDoc.Services
{
    public static class DoctorDataService
    {
        public static List<Doctor> Doctors = new List<Doctor>
        {
            new Doctor()
            {
                Id = 1,
                Name = "Vasyan1",
                Surname = "111",
                Age = 36,
                Specialization = "Проктолог",
                Experience = 17,
                Education = "Высшее",
                WorkTimeFull = new List<WorkTime>()
                {
                    new WorkTime()
                    {
                        StartHour = 8,
                        EndHour = 17,
                        Number = 16,
                    },
                    new WorkTime()
                    {
                        StartHour = 8,
                        EndHour = 17,
                        Number = 17,
                    },
                    new WorkTime()
                    {
                        StartHour = 8,
                        EndHour = 17,
                        Number = 18,
                    },
                    new WorkTime()
                    {
                        StartHour = 8,
                        EndHour = 17,
                        Number = 19,
                    },
                    new WorkTime()
                    {
                        StartHour = 8,
                        EndHour = 17,
                        Number = 20,
                    }
                },
            },

            new Doctor()
            {
                Id = 2,
                Name = "2",
                Surname = "222",
                Age = 36,
                Specialization = "Педиатр",
                Experience = 8,
                Education = "Высшее",
            },

            new Doctor()
            {
                Id = 3,
                Name = "3",
                Surname = "333",
                Age = 60,
                Specialization = "Хирург",
                Experience = 25,
                Education = "Не ПТУ, а колледж",
            },

            new Doctor()
            {
                Id = 4,
                Name = "4",
                Surname = "444",
                Age = 30,
                Specialization = "Проктолог",
                Experience = 5,
                Education = "Высшее",
            },

            new Doctor()
            {
                Id = 5,
                Name = "5",
                Surname = "555",
                Age = 30,
                Specialization = "Хирург",
                Experience = 5,
                Education = "Высшее",
            },
        };
    }
}
