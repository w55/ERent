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
    public class ApartmentRepository : IRepository<Apartment>
    {
        private RentContext db;

        public ApartmentRepository(RentContext context)
        {
            this.db = context;
        }

        public IEnumerable<Apartment> GetAll()
        {
            return db.Apartments.Include(a => a.Salesman)
                .Include(a => a.Balcony)
                .Include(a => a.ToiletType)
                .Include(a => a.RepairType)
                .Include(a => a.Elevator)
                .Include(a => a.House)
                .Include(a => a.House.BuildingType)
                .Include(a => a.ApartmentIncludes)
                .Include(a => a.ImagesIncludes);
        }

        public Apartment Get(int id)
        {
            return db.Apartments.Include(a => a.Salesman)
                .Include(a => a.Balcony)
                .Include(a => a.ToiletType)
                .Include(a => a.RepairType)
                .Include(a => a.Elevator)
                .Include(a => a.House)
                .Include(a => a.House.BuildingType)
                .Include(a => a.ApartmentIncludes)
                .Include(a => a.ImagesIncludes)
                .FirstOrDefault(a => a.Id == id);
        }

        public void Create(Apartment aparment)
        {
            db.Apartments.Add(aparment);
        }

        public void Update(Apartment aparment)
        {
            db.Entry(aparment).State = EntityState.Modified;
        }

        public IEnumerable<Apartment> Find(Func<Apartment, Boolean> predicate)
        {
            return db.Apartments.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Apartment aparment = db.Apartments.Find(id);
            if (aparment != null)
                db.Apartments.Remove(aparment);
        }
    }
}
