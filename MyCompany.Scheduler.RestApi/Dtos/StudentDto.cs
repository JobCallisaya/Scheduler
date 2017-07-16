using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Scheduler.RestApi.Dtos
{
    using MyCompany.Scheduler.Data;

    public class StudentDto
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The op_ implicit.
        /// </summary>
        /// <param name="student">
        /// The student.
        /// </param>
        /// <returns>
        /// </returns>
        public static implicit operator Student(StudentDto student)
        {
            return new Student() { Id = student.Id, FirstName = student.FirstName, LastName = student.LastName };
        }

        /// <summary>
        /// The op_ implicit.
        /// </summary>
        /// <param name="student">
        /// The student.
        /// </param>
        /// <returns>
        /// </returns>
        public static implicit operator StudentDto(Student student)
        {
            return new StudentDto() { Id = student.Id, FirstName = student.FirstName, LastName = student.LastName };
        }
    }
}
