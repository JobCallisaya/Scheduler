// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   IRepository.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    namespace MyCompany.Scheduler.DataAccess
    {
        /// <summary>
        /// Represents a repository. Holds a collection of data and provides actions over this data.
        /// </summary>
        /// <typeparam name="TData">The data type</typeparam>
        public interface IRepository<TData>
            where TData : class
        {
            /// <summary>
            /// Gets all data from repository
            /// </summary>
            /// <returns>All data from repository</returns>
            IQueryable<TData> Get();

            /// <summary>
            /// Gets data with identifier id
            /// </summary>
            /// <param name="id">The data identifier</param>
            /// <returns>The data with identifier id</returns>
            TData Get(int id);

            /// <summary>
            /// Gets data by an specified filter, orders the data given a function and retreives the specified properties
            /// </summary>
            /// <param name="filter">The filter</param>
            /// <param name="orderBy">The orderBy function</param>
            /// <param name="properties">The properties</param>
            /// <returns>A filtered and ordered IEnumerable of data</returns>
            IEnumerable<TData> Get(
                Expression<Func<TData, bool>> filter = null,
                Func<IQueryable<TData>, IOrderedQueryable<TData>> orderBy = null,
                params string[] properties);

            /// <summary>
            /// Adds data to repository
            /// </summary>
            /// <param name="data">The data to be added</param>
            /// <returns>The added data</returns>
            TData Add(TData data);

            /// <summary>
            /// Updates data in the repository
            /// </summary>
            /// <param name="data">The data to be updated</param>
            /// <returns>The updated data</returns>
            TData Update(TData data);

            /// <summary>
            /// Removes data from repository
            /// </summary>
            /// <param name="data">The data</param>
            /// <returns>The removed data</returns>
            TData Remove(TData data);

            /// <summary>
            /// Removes data from repository with identifier id
            /// </summary>
            /// <param name="id">The data identifier</param>
            /// <returns>The removed data</returns>
            TData Remove(int id);

            /// <summary>
            /// Removes all data in repository
            /// </summary>
            void Remove();
        }
    }
}
