﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Represents a unit of work. Encapsulates changes made on the repositories associated to this, allowing to save
//   these changes at once.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess
{
    using global::MyCompany.Scheduler.DataAccess.MyCompany.Scheduler.DataAccess;

    /// <summary>
    /// Represents a unit of work. Encapsulates changes made on the repositories associated to this, allowing to save 
    /// these changes at once.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// The repositories associated with this unit of work
        /// </summary>
        /// <typeparam name="TData">The data type that a certain repository handles</typeparam>
        /// <returns>The repository requested for TData</returns>
        IRepository<TData> GetRepository<TData>() where TData : class;

        /// <summary>
        /// Saves all of the changes made on all the repositories at once.
        /// </summary>
        /// <returns>The number of data objects changed.</returns>
        int SaveChanges();
    }
}
