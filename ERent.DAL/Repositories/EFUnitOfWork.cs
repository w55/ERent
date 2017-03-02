using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERent.DAL.EF;
using ERent.DAL.Interfaces;
using ERent.DAL.Entities;

namespace ERent.DAL.Repositories
{
    /// <summary>
    /// через EFUnitOfWork мы будем взаимодействовать с базой данных
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        private RentContext db;
        private SalesmanRepository salesmanRepository;
        private ApartmentRepository apartmentRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new RentContext(connectionString);
        }
        public IRepository<Salesman> Salesmans
        {
            get
            {
                if (salesmanRepository == null)
                    salesmanRepository = new SalesmanRepository(db);
                return salesmanRepository;
            }
        }

        public IRepository<Apartment> Apartments
        {
            get
            {
                if (apartmentRepository == null)
                    apartmentRepository = new ApartmentRepository(db);
                return apartmentRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
