// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentRepository.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Defines the StudentRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.DataAccess.SqlServer
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    using MyCompany.Scheduler.Commons;
    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.DataAccess.Common;
    using MyCompany.Scheduler.DataAccess.SqlServer.Common;
    using MyCompany.Scheduler.DataAccess.SqlServer.Repositories;

    /// <summary>
    /// The student repository.
    /// </summary>
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentRepository"/> class.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public StudentRepository(IDbTransaction transaction, IUnitOfWork unitOfWork)
            : base(transaction, unitOfWork)
        {
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public override IEnumerable<Student> Get()
        {
            return this.ExecuteCommand(
                command =>
                    {
                        command.CommandText = @"SELECT * FROM Student";
                        var students = Adapt(command, Adapt);
                        return students.ForEach(student => student.Classes = this.GetClases(student.Id));
                    });
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Student"/>.</returns>
        public override Student Get(int id)
        {
            return this.ExecuteCommand(
                command =>
                    {
                        command.Transaction = this.Transaction;
                        command.CommandText = @"SELECT Id, FirstName, LastName FROM Student WHERE Id = @Id";
                        command.AddParameter("Id", id);
                        return Adapt(command);
                    });
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public override IEnumerable<Student> Get(List<CustomExpression> filter)
        {
            return this.ExecuteCommand(
                command =>
                    {
                        command.CommandText = string.Format("SELECT * FROM Student {0}", this.GetWhereClause(filter));
                        var students = Adapt(command, Adapt);
                        return students.ForEach(student => student.Classes = this.GetClases(student.Id));
                    });
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="data">The data.</param>
        public override void Add(Student data)
        {
            this.ExecuteCommand(
                command =>
                    {
                        command.CommandText = @"INSERT INTO Student (Id, FirstName, LastName)
                                    VALUES(@Id, @FirstName, @LastName)";
                        command.AddParameter("Id", data.Id);
                        command.AddParameter("FirstName", data.FirstName);
                        command.AddParameter("LastName", data.LastName);

                        command.ExecuteNonQuery();
                    });
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="data">The data.</param>
        public override void Update(int id, Student data)
        {
            this.ExecuteCommand(
                command =>
                    {
                        command.Transaction = this.Transaction;
                        command.CommandText = @"UPDATE Student SET
                                        FirstName = @FirstName, 
                                        LastName = @LastName
                                    WHERE Id = @Id";
                        command.AddParameter("Id", id);
                        command.AddParameter("FirstName", data.FirstName);
                        command.AddParameter("LastName", data.LastName);

                        command.ExecuteNonQuery();
                    });
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="id">The id.</param>
        public override void Remove(int id)
        {
            this.ExecuteCommand(
                command =>
                    {
                        command.Transaction = this.Transaction;
                        command.CommandText = @"DELETE FROM Student WHERE Id = @Id";
                        command.AddParameter("Id", id);
                        command.ExecuteNonQuery();
                    });
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="data">The data.</param>
        public override void Remove(Student data)
        {
            this.ExecuteCommand(
                command =>
                    {
                        command.CommandText = @"DELETE FROM Student WHERE Id = @Id";
                        command.AddParameter("Id", data.Id);
                        command.ExecuteNonQuery();
                    });
        }

        /// <summary>
        /// The remove.
        /// </summary>
        public override void Remove()
        {
            this.ExecuteCommand(
                command =>
                    {
                        command.Transaction = this.Transaction;
                        command.CommandText = @"DELETE FROM Student";
                        command.ExecuteNonQuery();
                    });
        }

        /// <summary>
        /// The get clases.
        /// </summary>
        /// <param name="studentId">The student id.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<Clase> GetClases(int studentId)
        {
            return this.ExecuteCommand(
                command =>
                    {
                        command.Parameters.Clear();
                        command.CommandText = @"
                            SELECT Clase.Code, Clase.Title, Clase.Description
                            FROM ClaseStudent INNER JOIN Clase ON ClaseStudent.ClaseCode = Clase.Code
                            WHERE ClaseStudent.StudentId = @StudentId
                        ";

                        command.AddParameter("StudentId", studentId);
                        return Adapt(command, ClaseRepository.Adapt);
                    });
        }

        /// <summary>
        /// The adapt.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The <see cref="Student"/>.</returns>
        public static Student Adapt(IDbCommand command)
        {
            using (var reader = command.ExecuteReader())
            {
                return Adapt(reader);
            }
        }

        /// <summary>
        /// The adapt.
        /// </summary>
        /// <param name="record">The record.</param>
        /// <returns>The <see cref="Student"/>.</returns>
        public static Student Adapt(IDataRecord record)
        {
            return new Student
                              {
                                  Id = (int)record[0],
                                  FirstName = record[1] is DBNull ? string.Empty : (string)record[1],
                                  LastName = record[2] is DBNull ? string.Empty : (string)record[2]
                              };
        }
    }
}
