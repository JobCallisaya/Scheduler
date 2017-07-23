// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStudentRepository.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The StudentRepository interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess
{
    using System.Collections.Generic;

    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.DataAccess.Common;

    /// <summary>
    /// The StudentRepository interface.
    /// </summary>
    public interface IStudentRepository : IRepository<Student>
    {
        /// <summary>
        /// The get clases.
        /// </summary>
        /// <param name="studentId">
        /// The student id.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<Clase> GetClases(int studentId);
    }
}
