// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StudentController.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The student controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.RestApi
{
    using System.Collections.Generic;
    using System.Web.Http;

    /// <summary>
    /// The student controller.
    /// </summary>
    [RoutePrefix("api")]
    public class StudentController : BaseController
    {
        /// <summary>
        /// The get students.
        /// </summary>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpGet]
        [Route("students")]
        public IHttpActionResult GetStudents()
        {
            return this.Ok(new List<string>(){"Student1", "Student2"});
        }
    }
}
