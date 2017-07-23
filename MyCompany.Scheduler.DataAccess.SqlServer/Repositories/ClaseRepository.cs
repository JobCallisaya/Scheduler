// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClaseRepository.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The clase repository.
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
    /// The clase repository.
    /// </summary>
    public class ClaseRepository : BaseRepository<Clase>, IClaseRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClaseRepository"/> class.
        /// </summary>
        /// <param name="transaction">The transaction.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public ClaseRepository(IDbTransaction transaction, IUnitOfWork unitOfWork) : base(transaction, unitOfWork)
        {   
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public override IEnumerable<Clase> Get()
        {
            return this.ExecuteCommand(
                command =>
                    {
                        command.CommandText = @"SELECT * FROM Clase";
                        var classes = Adapt(command, Adapt);
                        return classes.ForEach(clase => clase.Students = this.GetStudents(clase.Code));
                    });
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The <see cref="Clase"/>.</returns>
        public override Clase Get(int id)
        {
            return this.ExecuteCommand(
                command =>
                    {
                        command.CommandText = @"SELECT * FROM Clase WHERE Code = @Code";
                        command.AddParameter("Code", id);
                        return Adapt(command);
                    });
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public override IEnumerable<Clase> Get(List<CustomExpression> filter)
        {
            return this.ExecuteCommand(
                command =>
                    {
                        command.CommandText = string.Format("SELECT * FROM Clase {0}", this.GetWhereClause(filter));
                        var clases = Adapt(command, Adapt);
                        return clases.ForEach(clase => clase.Students = this.GetStudents(clase.Code));
                    });
        }

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="data">The data.</param>
        public override void Add(Clase data)
        {
            this.ExecuteCommand(
                command =>
                    {
                        command.CommandText = @"INSERT INTO Clase (Code, Title, Description)
                                    VALUES(@Code, @Title, @Description)";
                        command.AddParameter("Code", data.Code);
                        command.AddParameter("Title", data.Title);
                        command.AddParameter("Description", data.Description);
                        command.ExecuteNonQuery();
                    });
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="data">The data.</param>
        public override void Update(int id, Clase data)
        {
            this.ExecuteCommand(
                command =>
                    {
                        command.CommandText = @"UPDATE Clase SET 
                                    Title = @Title, Description = @Description WHERE Code = @Code";
                        command.AddParameter("Code", data.Code);
                        command.AddParameter("Title", data.Title);
                        command.AddParameter("Description", data.Description);
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
                        command.CommandText = @"DELETE FROM Clase WHERE Code = @Code";
                        command.AddParameter("Code", id);
                        command.ExecuteNonQuery();
                    });
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="data">The data.</param>
        public override void Remove(Clase data)
        {
            this.ExecuteCommand(
                command =>
                    {
                        command.CommandText = @"DELETE FROM Clase WHERE Code = @Code";
                        command.AddParameter("Code", data.Code);
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
                        command.CommandText = @"DELETE FROM Clase";
                        command.ExecuteNonQuery();
                    });
        }

        /// <summary>
        /// The add student to class.
        /// </summary>
        /// <param name="classId">The class id.</param>
        /// <param name="studentId">The student id.</param>
        public void AddStudentToClass(int classId, int studentId)
        {
            this.ExecuteCommand(
                command =>
                    {
                        command.CommandText = @"INSERT INTO ClaseStudent (ClaseCode, StudentId)
                                    VALUES(@ClaseCode, @StudentId)";
                        command.AddParameter("ClaseCode", classId);
                        command.AddParameter("StudentId", studentId);
                        command.ExecuteNonQuery();
                    });
        }

        /// <summary>
        /// The get students.
        /// </summary>
        /// <param name="classCode">The class code.</param>
        /// <returns>The <see cref="IEnumerable"/>.</returns>
        public IEnumerable<Student> GetStudents(int classCode)
        {
            return this.ExecuteCommand(
                command =>
                    {
                        command.CommandText = @"
                            SELECT Student.Id, Student.FirstName, Student.LastName
                            FROM ClaseStudent INNER JOIN Student ON ClaseStudent.StudentId = Student.Id
                            WHERE ClaseStudent.ClaseCode = @ClaseCode
                        ";
                        command.AddParameter("ClaseCode", classCode);
                        return Adapt(command, StudentRepository.Adapt);
                    });
        }

        /// <summary>
        /// The adapt.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The <see cref="Clase"/>.</returns>
        public static Clase Adapt(IDbCommand command)
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
        /// <returns>The <see cref="Clase"/>.</returns>
        public static Clase Adapt(IDataRecord record)
        {
            return new Clase
                          {
                              Code = (int)record[0],
                              Title = record[1] is DBNull ? string.Empty : (string)record[1],
                              Description = record[2] is DBNull ? string.Empty : (string)record[2]
                          };
        }
    }
}
