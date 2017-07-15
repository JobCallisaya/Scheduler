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
    /// <summary>
    /// The class.
    /// </summary>
    public class Class
    {
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

        public override int GetHashCode()
        {
            return this.Code;
        }
    }
}
