using FlightBook.Data.DatabaseContext;
using FlightBooking.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Data.Repository
{
    public class GeneralRepository<T> : Context, IGeneralRepository<T> where T : class
    {
        protected FlightManageBookDBContext db = null;
        protected DbSet<T> entity = null;

        public GeneralRepository():base()
        {
            if (this.db == null)
                this.db = base.db;
            entity = db.Set<T>();
        }

        public GeneralRepository(FlightManageBookDBContext db)
        {
            if (this.db == null)
                this.db = db;
            entity = db.Set<T>();
        }

        public virtual void Add(T entity)
        {

            this.entity.Add(entity);
        }

        public virtual IQueryable<T> GetAll(int page = 0)
        {

            if (page == 0)
                return entity
                    .AsNoTracking()
                    .AsQueryable();
            return entity.AsQueryable().AsNoTracking().Skip(() => page - 18).Take(() => 18);
        }

        public virtual void Save()
        {
            try
            {

                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                List<string> errorMessages = new List<string>();
                foreach (DbEntityValidationResult validationResult in ex.EntityValidationErrors)
                {
                    string entityName = validationResult.Entry.Entity.GetType().Name;
                    foreach (DbValidationError error in validationResult.ValidationErrors)
                    {
                        errorMessages.Add(entityName + "." + error.PropertyName + ": " + error.ErrorMessage);
                    }
                }
            }
        }

        public virtual T LoadById(object id)
        {
            T thisentity = entity.Find(id);
            db.Entry(thisentity).State = EntityState.Unchanged;
            return thisentity;
        }

        public virtual void Update(T obj)
        {
            entity.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = entity.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (db.Entry(entityToDelete).State == EntityState.Detached)
            {
                entity.Attach(entityToDelete);
            }
            entity.Remove(entityToDelete);
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
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
