// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDependencyScope.cs" company="">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Defines the IDependencyScope type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DependencyInjection
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The DependencyScope interface.
    /// </summary>
    public interface IDependencyScope : IDisposable
    {
        /// <summary>
        /// The get service.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object GetService(Type serviceType);

        /// <summary>
        /// The get services.
        /// </summary>
        /// <param name="serviceType">
        /// The service type.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<object> GetServices(Type serviceType);
    }
}
