using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Scheduler.RestApi.Dtos
{
    using MyCompany.Scheduler.Data;

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
