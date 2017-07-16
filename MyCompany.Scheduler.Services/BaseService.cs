// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseService.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The base manager with which to manage one type of data
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyCompany.Scheduler.Commons;
    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.DataAccess;
    using MyCompany.Scheduler.DataAccess.MyCompany.Scheduler.DataAccess;

    /// <summary>
    /// The base manager with which to manage one type of data
    /// </summary>
    /// <typeparam name="TData">The type of data managed by this class</typeparam>
    public class BaseService<TData> : IService<TData> where TData : class
    {
        /// <summary>
        /// The unit of work with which to perform changes on data repositories.
        /// </summary>
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// The data repository that will be manipulated by this manager in order to perform operations.
        /// </summary>
        private IRepository<TData> repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseService{TData}"/> class. 
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work with which to perform changes on data repositories.
        /// </param>
        /// <exception cref="System.ArgumentNullException">
        /// When unitOfWork is null.
        /// </exception>
        public BaseService(IUnitOfWork unitOfWork)
        {
            Validator.ValidateNullArgument(unitOfWork, "unitOfWork");
            this.unitOfWork = unitOfWork;
            this.repository = unitOfWork.GetRepository<TData>();
        }

        /// <summary>
        /// Gets all data from repository
        /// </summary>
        /// <returns>All data from repository</returns>
        public virtual IQueryable<TData> Get()
        {
            return this.repository.Get();
        }

        /// <summary>
        /// Gets data with identifier id
        /// </summary>
        /// <param name="id">The data identifier</param>
        /// <returns>The data with identifier id</returns>
        public virtual TData Get(int id)
        {
            return this.repository.Get(id);
        }

        /// <summary>
        /// Adds data to repository
        /// </summary>
        /// <param name="data">The data to be added</param>
        /// <returns>The added data</returns>
        public virtual TData Add(TData data)
        {
            return this.repository.Add(data);
        }

        /// <summary>
        /// Removes data from repository
        /// </summary>
        /// <param name="data">The data to be removed</param>
        /// <returns>The removed data</returns>
        public virtual TData Remove(TData data)
        {
            return this.repository.Remove(data);
        }

        /// <summary>
        /// Removes data from repository with identifier id
        /// </summary>
        /// <param name="id">The data identifier</param>
        /// <returns>The removed data</returns>
        public virtual TData Remove(int id)
        {
            return this.repository.Remove(id);
        }

        /// <summary>
        /// Updates data in repository.
        /// </summary>
        /// <param name="data">The data to be updated</param>
        /// <returns>The updated data</returns>
        public virtual TData Update(int id, TData data)
        {
            return this.repository.Update(id, data);
        }

        /// <summary>
        /// Removes all data in repository
        /// </summary>
        public virtual void Remove()
        {
            this.repository.Remove();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {   
        }

        public IEnumerable<TData> Get(List<CustomExpression> filter)
        {
            return this.repository.Get(filter);
        }
    }
}
