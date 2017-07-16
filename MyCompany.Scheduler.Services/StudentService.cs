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
        /// The get classes.
        /// </summary>
        /// <param name="studentId">
        /// The student id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Class> GetClasses(int studentId)
        {
            return this.Get(studentId).Classes;
        }
    }
}
