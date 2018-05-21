using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Data.Repository
{
   public interface IGeneralRepository<T>: IDisposable where T : class
    {
        IQueryable<T> GetAll(int page);
        T LoadById(object id);
        void Add(T obj);
        void Update(T obj);
        void Delete(object obj);
        void Delete(T id);
        void Save();
        void Dispose(bool disposing);
    }
}
