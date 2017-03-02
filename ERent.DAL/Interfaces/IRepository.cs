using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ERent.DAL.Entities;

namespace ERent.DAL.Interfaces
{
    /// <summary>
    /// интерфейс репозиториев
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }

    /// <summary>
    /// будем использовать паттерн Unit Of Work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Salesman> Salesmans { get; }
        IRepository<Apartment> Apartments { get; }
        void Save();
    }
}
