using FlightBook.Application.Common;
using FlightBook.Data.DomainModel;
using FlightBook.Data.Repository;
using FlightBook.Data.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightBook.Application.Services
{
  public  class DomainCrudFacade<T> where T:class
    {
        protected virtual IGeneralRepository<T> CreateRepository()
        {
                return Factory.GetObject<IGeneralRepository<T>>();
        }

        #region Create
        public virtual void Create(IGeneralRepository<T> repository, T domainModel)
        {
         
            try
            {
                repository.Add(domainModel);
                repository.Save();
            }
            catch (DataException ex)
            {
                throw new ApplicationException(ex.Message);
            }
            catch (Exception ex)
            {
                Exception innerEx = ex;
                while (innerEx.InnerException != null)
                    innerEx = innerEx.InnerException;
                throw new ApplicationException(innerEx.Message);
            }
        }
        public virtual void Create(T domainModel)
        {

            using (IGeneralRepository<T> repository = CreateRepository())
            {
                Create(repository, domainModel);
            }
        }

        #endregion

        

        #region Read
        /// <summary>
        /// Find by entity
        /// </summary>
        /// <typeparam name="T">entity type</typeparam>
        /// <param name="id">id</param>
        /// <returns>entity type</returns>
        public virtual T FindEntity(long id)
        {
            using (IGeneralRepository<T> repository = CreateRepository())
            {

                return repository.LoadById(id) as T;
            }
        }

        /// <summary>
        /// Find all
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public virtual IList<T> FindAll()
        {
            using (IGeneralRepository<T> repository = CreateRepository())
            {
                return repository.GetAll(0).ToList();
            }
        }

        #endregion

    }
}
