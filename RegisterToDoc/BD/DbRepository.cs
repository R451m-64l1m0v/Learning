using RegisterToDoc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RegisterToDoc.BD
{
    public class DbRepository<T> : IDbRepository<T> where T : BaseEntity
    {
        public ApplicationDBContext DbContext { get; }

        public DbRepository(ApplicationDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Delete(T t)
        {
            DbContext.Set<T>().Remove(t);
            DbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return DbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return DbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public void Insert(T t)
        {
            DbContext.Set<T>().Add(t);
            DbContext.SaveChanges();
        }

        public void Update(T t)
        {
            DbContext.Set<T>().Update(t);
            DbContext.SaveChanges();
        }


        //public IEnumerable<Doctor> GetDoctors()
        //{
        //    throw new NotImplementedException();
        //}

        //public Doctor GetDoctorById(int doctorId)
        //{
        //    var currentDoctor = DbContext.Doctors
        //        .Include(x => x.WorkGraphic)
        //        .ThenInclude(x => x.Intervals)
        //        .FirstOrDefault(x => x.Id == doctorId);

        //    return currentDoctor;
        //}

       

        //public List<string> GetSpecialization()
        //{
        //    return DbContext.Doctors.Select(x => x.Specialization).ToList();
        //}

        //public List<Doctor> GetDoctorsByFilter(string specialization, int experience)
        //{
        //    return DbContext.Doctors.Where(x => x.Specialization == specialization)
        //        .Where(x => x.Experience >= experience).ToList();
        //}

        //public void InsertWorkDay(int idDoctor, int dayNumber, int @from, int to)
        //{
        //    DbContext.Doctors
        //        .Include(x => x.WorkGraphic)
        //        .FirstOrDefault(x => x.Id == idDoctor);


        //}

        //public void DeleteDoctor(int doctorID)
        //{
        //    throw new NotImplementedException();
        //}

        //public void UpdateDoctor(Doctor doctor)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
