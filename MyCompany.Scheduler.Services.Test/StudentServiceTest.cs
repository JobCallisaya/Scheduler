// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentServiceTest.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Defines the StudentServiceTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.Services.Test
{
    using System.Linq;

    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.DataAccess;
    using MyCompany.Scheduler.DataAccess.Memory;

    using NUnit.Framework;

    /// <summary>
    /// The student service test.
    /// </summary>
    [TestFixture]
    public class StudentServiceTest
    {
        /// <summary>
        /// The student service.
        /// </summary>
        private StudentService studentService;

        /// <summary>
        /// The unit of work.
        /// </summary>
        private IUnitOfWork unitOfWork;

        /// <summary>
        /// The set up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.unitOfWork = new MemoryUnitOfWork();
            this.studentService = new StudentService(this.unitOfWork);
        }

        /// <summary>
        /// The tear down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            this.studentService.Remove();
            this.unitOfWork.Dispose();
            this.studentService.Dispose();
        }

        /// <summary>
        /// The get_ get all data_ success.
        /// </summary>
        [Test]
        public void Get_GetAllData_Success()
        {
            string firstName = "FirstName";
            string lastName = "LastName";

            this.studentService.Add(new Student() { Id = 1, FirstName = firstName, LastName = lastName });
            this.studentService.Add(new Student() { Id = 2, FirstName = firstName, LastName = lastName });

            var students = this.studentService.Get();

            Assert.AreEqual(2, students.Count());
            Assert.AreEqual(1, students.First().Id);
            Assert.AreEqual(firstName, students.First().FirstName);
            Assert.AreEqual(lastName, students.First().LastName);
        }

        /// <summary>
        /// The remove_ remove student_ success.
        /// </summary>
        [Test]
        public void Remove_RemoveStudent_Success()
        {
            string firstName = "FirstName";
            string lastName = "LastName";

            this.studentService.Add(new Student() { Id = 1, FirstName = firstName, LastName = lastName });
            this.studentService.Add(new Student() { Id = 2, FirstName = firstName, LastName = lastName });

            this.studentService.Remove(1);
            var students = this.studentService.Get();

            Assert.AreEqual(1, students.Count());
            Assert.AreEqual(2, students.First().Id);
            Assert.AreEqual(firstName, students.First().FirstName);
            Assert.AreEqual(lastName, students.First().LastName);
        }
    }
}
