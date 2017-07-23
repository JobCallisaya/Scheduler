// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IClaseRepository.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Defines the IClaseRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess
{
    using System.Collections.Generic;

    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.DataAccess.Common;

    /// <summary>
    /// The ClaseRepository interface.
    /// </summary>
    public interface IClaseRepository : IRepository<Clase>
    {
        /// <summary>
        /// The add student to class.
        /// </summary>
        /// <param name="classId">
        /// The class id.
        /// </param>
        /// <param name="studentId">
        /// The student id.
        /// </param>
        void AddStudentToClass(int classId, int studentId);

        /// <summary>
        /// The get students.
        /// </summary>
        /// <param name="classCode">
        /// The class code.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<Student> GetStudents(int classCode);
    }
}
