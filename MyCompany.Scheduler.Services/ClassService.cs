// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassService.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The Class service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.Services
{
    using System.Collections.Generic;

    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.DataAccess;
    using MyCompany.Scheduler.DataAccess.Common;

    /// <summary>
    /// The Class service.
    /// </summary>
    public class ClassService : BaseService<Clase>
    {
        /// <summary>
        /// The student repository.
        /// </summary>
        private IRepository<Student> studentRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClassService"/> class.
        /// </summary>
        /// <param name="unitOfWork">
        /// The unit of work.
        /// </param>
        public ClassService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.studentRepository = unitOfWork.GetRepository<Student>();
        }

        /// <summary>
        /// The add student to class.
        /// </summary>
        /// <param name="classId">
        /// The class id.
        /// </param>
        /// <param name="studentId">
        /// The student id.
        /// </param>
        public void AddStudentToClass(int classId, int studentId)
        {
            ((IClaseRepository)this.Repository).AddStudentToClass(classId, studentId);
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
        public IEnumerable<Student> GetStudents(int classCode)
        {
            return ((IClaseRepository)this.Repository).GetStudents(classCode);
        }
    }
}
