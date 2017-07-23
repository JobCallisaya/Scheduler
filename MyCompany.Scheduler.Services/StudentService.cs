// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentService.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The student service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.Services
{
    using System.Collections.Generic;

    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.DataAccess;
    using MyCompany.Scheduler.DataAccess.Common;

    /// <summary>
    /// The student service.
    /// </summary>
    public class StudentService : BaseService<Student>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentService"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public StudentService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        /// <summary>
        /// The get students.
        /// </summary>
        /// <param name="classId">
        /// The class id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public IEnumerable<Clase> GetClases(int studentId)
        {
            return ((IStudentRepository)this.Repository).GetClases(studentId);
        }
    }
}
