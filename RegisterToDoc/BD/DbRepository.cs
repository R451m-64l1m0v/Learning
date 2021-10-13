using RegisterToDoc.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RegisterToDoc.BD
{
    public class DbRepository<T> : IDbRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDBContext DbContext;

        public IQueryable<T> Entity => DbContext.Set<T>();

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
    }
}
