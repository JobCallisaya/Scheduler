// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   IRepository.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Represents a repository. Holds a collection of data and provides actions over this data.
    /// </summary>
    /// <typeparam name="TData">The data type</typeparam>
    public interface IRepository<TData> where TData : class, new()
    {
        /// <summary>
        /// Gets all data from repository
        /// </summary>
        /// <returns>All data from repository</returns>
        IEnumerable<TData> Get();

        /// <summary>
        /// Gets data with identifier id
        /// </summary>
        /// <param name="id">The data identifier</param>
        /// <returns>The data with identifier id</returns>
        TData Get(int id);

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<TData> Get(List<CustomExpression> filter);

        /// <summary>
        /// Adds data to repository
        /// </summary>
        /// <param name="data">The data to be added</param>
        /// <returns>The added data</returns>
        void Add(TData data);

        /// <summary>
        /// Updates data in the repository
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
        void Update(int id, TData data);

        /// <summary>
        /// Removes data from repository with identifier id
        /// </summary>
        /// <param name="id">The data identifier</param>
        /// <returns>The removed data</returns>
        void Remove(int id);

        /// <summary>
        /// Removes data from repository
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The removed data</returns>
        void Remove(TData data);

        /// <summary>
        /// Removes all data in repository
        /// </summary>
        void Remove();
    }
}

