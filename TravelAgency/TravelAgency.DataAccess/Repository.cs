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

        public async Task Delete(int id)
        {
            T entity= await entities.SingleOrDefaultAsync(s=>s.Id==id);
            entities.Remove(entity);
            await contex.SaveChangesAsync();
        }

        public Task<List<T>> GetAll()
        {
            return entities.ToListAsync();
        }

        public Task<T> GetById(int id)
        {
            return entities.SingleOrDefaultAsync(s=>s.Id == id);
        }

        public async Task Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            await contex.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            await contex.SaveChangesAsync();
        }
    }
}
