using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RegisterToDoc.Models;

namespace RegisterToDoc.BD
{
    public interface IDbRepository<T> where T : BaseEntity
    {
        ApplicationDBContext DbContext { get; }

        IEnumerable<T> GetAll();
        T GetById(int id);
        void Insert(T t);
        void Delete(T t);
        void Update(T t);
    }
}
