// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassDto.cs" company="//   Copyright (c) MyCompany.">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Defines the ClassDto type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.RestApi.Dtos
{
    using MyCompany.Scheduler.Data;

    /// <summary>
    /// The class DTO.
    /// </summary>
    public class ClassDto
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

        /// <summary>
        /// The op_ implicit.
        /// </summary>
        /// <param name="clase">
        /// The class.
        /// </param>
        /// <returns>
        /// </returns>
        public static implicit operator Class(ClassDto clase)
        {
            return new Class() { Code = clase.Code, Title = clase.Title, Description = clase.Description};
        }

        /// <summary>
        /// The op_ implicit.
        /// </summary>
        /// <param name="clase">
        /// The class.
        /// </param>
        /// <returns>
        /// </returns>
        public static implicit operator ClassDto(Class clase)
        {
            return new ClassDto() { Code = clase.Code, Title = clase.Title, Description = clase.Description};
        }
    }
}
