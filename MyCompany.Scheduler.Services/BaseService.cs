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
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Remoting.Messaging;

    using MyCompany.Scheduler.Commons;
    using MyCompany.Scheduler.DataAccess;
    using MyCompany.Scheduler.DataAccess.Common;

    /// <summary>
    /// The base manager with which to manage one type of data
    /// </summary>
    /// <typeparam name="TData">The type of data managed by this class</typeparam>
    public class BaseService<TData> : IService<TData> where TData : class, new()
    {
        /// <summary>
        /// The unit of work with which to perform changes on data repositories.
        /// </summary>
        protected IUnitOfWork UnitOfWork { get; private set; }

        /// <summary>
        /// The data repository that will be manipulated by this manager in order to perform operations.
        /// </summary>
        protected IRepository<TData> Repository { get; private set; }

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
            this.UnitOfWork = unitOfWork;
            this.Repository = unitOfWork.GetRepository<TData>();
        }

        /// <summary>
        /// Gets all data from repository
        /// </summary>
        /// <returns>All data from repository</returns>
        public virtual IEnumerable<TData> Get()
        {
            return this.Repository.Get();
        }

        /// <summary>
        /// Gets data with identifier id
        /// </summary>
        /// <param name="id">The data identifier</param>
        /// <returns>The data with identifier id</returns>
        public virtual TData Get(int id)
        {
            return this.Repository.Get(id);
        }

        /// <summary>
        /// Adds data to repository
        /// </summary>
        /// <param name="data">The data to be added</param>
        /// <returns>The added data</returns>
        public virtual void Add(TData data)
        {
            this.Repository.Add(data);
        }

        /// <summary>
        /// Removes data from repository
        /// </summary>
        /// <param name="data">The data to be removed</param>
        /// <returns>The removed data</returns>
        public virtual void Remove(TData data)
        {
            this.Repository.Remove(data);
        }

        /// <summary>
        /// Removes data from repository with identifier id
        /// </summary>
        /// <param name="id">The data identifier</param>
        /// <returns>The removed data</returns>
        public virtual void Remove(int id)
        {
            this.Repository.Remove(id);
        }

        /// <summary>
        /// Updates data in repository.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="data">
        /// The data to be updated
        /// </param>
        /// <returns>
        /// The updated data
        /// </returns>
        public virtual void Update(int id, TData data)
        {
            this.Repository.Update(id, data);
        }

        /// <summary>
        /// Removes all data in repository
        /// </summary>
        public virtual void Remove()
        {
            this.Repository.Remove();
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {   
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<TData> Get(List<CustomExpression> filter)
        {
            return this.Repository.Get(filter);
        }
    }
}
