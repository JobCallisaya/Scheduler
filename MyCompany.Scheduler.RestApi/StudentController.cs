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

    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.Services;

    /// <summary>
    /// The student controller.
    /// </summary>
    [RoutePrefix("api")]
    public class StudentController : BaseController<Student>
    {
        public StudentController(IService<Student> service)
            : base(service)
        {
        }

        /// <summary>
        /// The get students.
        /// </summary>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpGet]
        [Route("students")]
        public override IHttpActionResult Get()
        {
            return base.Get();
        }

        [HttpPost]
        [Route("students")]
        public override IHttpActionResult Create(Student student)
        {
            return base.Create(student);
        }
    }
}
