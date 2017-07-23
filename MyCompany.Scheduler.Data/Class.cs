// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Class.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Defines the Class type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.Data
{
    using System.Collections.Generic;

    /// <summary>
    /// The class.
    /// </summary>
    public class Clase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Clase"/> class.
        /// </summary>
        public Clase()
        {
            this.Students = new List<Student>();
        }

        /// <summary>
        /// Gets or sets the code.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        public IEnumerable<Student> Students { get; set; }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Code;
        }
    }
}
