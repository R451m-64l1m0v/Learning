using RegisterToDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterToDoc.BD
{
    public interface IUnitOfWork : IDisposable
    {       
        public IDbRepository<T> DbRepository<T>() where T : BaseEntity;
    }
}
