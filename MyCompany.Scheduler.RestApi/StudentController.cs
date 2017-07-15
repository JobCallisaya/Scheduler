﻿// --------------------------------------------------------------------------------------------------------------------
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
    [Route("")]
    public class StudentController : BaseController<Student>
    {
        public StudentController(IService<Student> service)
            : base(service)
        {
        }

        [HttpPost]
        [Route("students")]
        public override IHttpActionResult Create(Student student)
        {
            return base.Create(student);
        }

        [HttpPut]
        [Route("students/{id}")]
        public override IHttpActionResult Update(int id, Student student)
        {
            return base.Update(id, student);
        }

        [HttpDelete]
        [Route("students/{id}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
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
    }
}
