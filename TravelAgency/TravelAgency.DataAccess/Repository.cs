using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgency.DataAccess.Entities;

namespace TravelAgency.DataAccess
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private readonly TravelAgencyContex contex;
        private DbSet<T> entities;
        public Repository(TravelAgencyContex contex)
        {
            this.contex = contex;
            this.entities = contex.Set<T>();
        }

        public void Delete(int id)
        {
            T entity=entities.SingleOrDefault(s=>s.Id==id);
            entities.Remove(entity);
            contex.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return entities.SingleOrDefault(s=>s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            contex.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            contex.SaveChanges();
        }
    }
}
