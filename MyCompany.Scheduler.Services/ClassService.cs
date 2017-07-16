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

    /// <summary>
    /// The Class service.
    /// </summary>
    public class ClassService : BaseService<Class>
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
            var clase = this.Get(classId);
            var student = this.studentRepository.Get(studentId);
            clase.Students.Add(student);
            student.Classes.Add(clase);
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
        public List<Student> GetStudents(int classId)
        {
            return this.Get(classId).Students;
        }
    }
}
