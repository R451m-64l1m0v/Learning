using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterToDoc.Models;

namespace RegisterToDoc.Services
{
    public class DoctorDataService
    {
        public List<Doctor> GetDoctorsList()
        {
            var list = new List<Doctor>();
            var doctor1 = new Doctor();
            var doctor2 = new Doctor();
            var doctor3 = new Doctor();
            var doctor4 = new Doctor();
            var doctor5 = new Doctor();

            doctor1.Id = 1;
            doctor1.Name = "1";
            doctor1.Surname = "111";
            doctor2.Age = 36;
            doctor1.Specialization = "Проктолог";
            doctor1.Experience = 17;
            doctor1.Education = "Высшее";

            doctor2.Id = 2;
            doctor2.Name = "2";
            doctor2.Surname = "222";
            doctor2.Age = 36;
            doctor2.Specialization = "Педиатр";
            doctor2.Experience = 8;
            doctor2.Education = "Высшее";

            doctor3.Id = 3;
            doctor3.Name = "3";
            doctor3.Surname = "333";
            doctor3.Age = 60;
            doctor3.Specialization = "Хирург";
            doctor3.Experience = 25;
            doctor3.Education = "Не ПТУ, а колледж";

            doctor4.Id = 4;
            doctor4.Name = "4";
            doctor4.Surname = "444";
            doctor4.Age = 30;
            doctor4.Specialization = "Проктолог";
            doctor4.Experience = 5;
            doctor4.Education = "Высшее";

            doctor5.Id = 5;
            doctor5.Name = "5";
            doctor5.Surname = "555";
            doctor5.Age = 30;
            doctor5.Specialization = "Хирург";
            doctor5.Experience = 5;
            doctor5.Education = "Высшее";


            list.Add(doctor1);
            list.Add(doctor2);
            list.Add(doctor3);
            list.Add(doctor4);
            list.Add(doctor5);

            return list;
        }
    }
}
