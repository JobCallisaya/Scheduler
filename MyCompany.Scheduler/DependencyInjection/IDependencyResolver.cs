// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDependencyResolver.cs" company="Mycompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Defines the IDependencyResolver type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DependencyInjection
{
    using System;

    /// <summary>
    /// The DependencyResolver interface.
    /// </summary>
    public interface IDependencyResolver : IDependencyScope, IDisposable
    {
        /// <summary>
        /// The begin scope.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependencyScope"/>.
        /// </returns>
        IDependencyScope BeginScope();
    }
}
