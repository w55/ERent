using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERent.DAL.Entities;
using ERent.DAL.EF;
using ERent.DAL.Interfaces;
using System.Data.Entity;

namespace ERent.DAL.Repositories
{
    public class SalesmanRepository : IRepository<Salesman>
    {
        private RentContext db;

        public SalesmanRepository(RentContext context)
        {
            this.db = context;
        }

        public IEnumerable<Salesman> GetAll()
        {
            return db.Salesmans;
        }

        public Salesman Get(int id)
        {
            return db.Salesmans.Find(id);
        }

        public void Create(Salesman salesman)
        {
            db.Salesmans.Add(salesman);
        }

        public void Update(Salesman salesman)
        {
            db.Entry(salesman).State = EntityState.Modified;
        }

        public IEnumerable<Salesman> Find(Func<Salesman, Boolean> predicate)
        {
            return db.Salesmans.Where(predicate).ToList();
        }
 
        public void Delete(int id)
        {
            Salesman salesman = db.Salesmans.Find(id);
            if (salesman != null)
                db.Salesmans.Remove(salesman);
        }
    }
}
