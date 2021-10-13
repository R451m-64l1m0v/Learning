using RegisterToDoc.BD;
using RegisterToDoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterToDoc.Services
{
    public class CatalogsService
    {
        private readonly IDbRepository<Specialization> specRepository;
        private readonly IDbRepository<Department> depRepository;

        public CatalogsService(IDbRepository<Specialization> specRepository, IDbRepository<Department> depRepository)
        {
            this.specRepository = specRepository;
            this.depRepository = depRepository;
        }

        public void InserSpecialization(string specNane)
        {
            var spec = new Specialization();
            spec.Name = specNane;
            specRepository.Insert(spec);
        }

        public List<string> GetSpecializations()
        {
            var specs = specRepository.GetAll().Select(x => x.Name).ToList();

            return specs;
        }

        public void InserDepartment(string depNane)
        {
            var dep = new Department();
            dep.Name = depNane;
            depRepository.Insert(dep);
        }

        public List<string> GetDepartments()
        {
            var deps = depRepository.GetAll().Select(x => x.Name).ToList();

            return deps;
        }
    }
}
