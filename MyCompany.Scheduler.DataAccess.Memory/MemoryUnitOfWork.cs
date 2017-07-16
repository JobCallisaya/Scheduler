// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemoryUnitOfWork.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   EF Implementation of a unit of work
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess.Memory
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// EF Implementation of a unit of work
    /// </summary>
    public class MemoryUnitOfWork : IUnitOfWork, IDisposable
    {
        /// <summary>
        /// Dictionary of repositories managed by this unit of work.
        /// </summary>
        private static Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        /// <summary>
        /// Saves all changes made in this unit of work to the underlying database.
        /// </summary>
        /// <returns>The number of objects written to the underlying database.</returns>
        /// <exception cref="System.InvalidOperationException">When context has been disposed.</exception>
        public int SaveChanges()
        {
            return 0;
        }

        /// <summary>
        /// Disposes the underlying context in this unit of work. The connection to the data base is also disposed.
        /// </summary>
        public void Dispose()
        {   
        }

        /// <summary>
        /// Gets a repository for a given TData.
        /// </summary>
        /// <typeparam name="TData">The TData for which we want a repository</typeparam>
        /// <returns>The repository for TData</returns>
        public IRepository<TData> GetRepository<TData>() where TData : class
        {
            IRepository<TData> repository = null;
            if (repositories.ContainsKey(typeof(TData)))
            {
                repository = repositories[typeof(TData)] as IRepository<TData>;
            }
            else
            {
                repository = new MemoryRepository<TData>();
                repositories[typeof(TData)] = repository;
            }

            return repository;
        }
    }
}
