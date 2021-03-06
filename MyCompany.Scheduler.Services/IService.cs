﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IService.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The Service interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using MyCompany.Scheduler.DataAccess;
    using MyCompany.Scheduler.DataAccess.Common;

    /// <summary>
    /// The Service interface.
    /// </summary>
    /// <typeparam name="TData">
    /// The data type parameter.
    /// </typeparam>
    public interface IService<TData> : IDisposable
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
        /// Removes data from repository
        /// </summary>
        /// <param name="data">The data to be removed</param>
        /// <returns>The removed data</returns>
        void Remove(TData data);

        /// <summary>
        /// Removes data from repository with identifier id
        /// </summary>
        /// <param name="id">The data identifier</param>
        /// <returns>The removed data</returns>
        void Remove(int id);

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
        void Update(int id, TData data);

        /// <summary>
        /// Removes all data in repository
        /// </summary>
        void Remove();
    }
}
