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
    using System.Linq;
    using System.Net;
    using System.Web.Http;

    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.DataAccess;
    using MyCompany.Scheduler.RestApi.Dtos;
    using MyCompany.Scheduler.Services;

    /// <summary>
    /// The student controller.
    /// </summary>
    [RoutePrefix("api")]
    [Route("")]
    public class StudentController : BaseController<Student, StudentDto>
    {
        public StudentController(IService<Student> service)
            : base(service)
        {
        }

        [HttpPost]
        [Route("students")]
        public override IHttpActionResult Create(StudentDto student)
        {
            return base.Create(student);
        }

        [HttpPut]
        [Route("students/{id}")]
        public override IHttpActionResult Update(int id, StudentDto student)
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

        [HttpGet]
        [Route("students/{id}/classes")]
        public IHttpActionResult GetClasses(int id)
        {
            var students = this.Service.Get();
            var student1 = students.FirstOrDefault(student => student.Id == id);

            return this.Ok(
                this.Service.Get().FirstOrDefault(student => student.Id == id)
                .Classes.Select(clase => (ClassDto)clase));
        }

        [HttpPost]
        [Route("students/filter")]
        public override IHttpActionResult Get(List<CustomExpression> filter)
        {
            return base.Get(filter);
        }

        /// <summary>
        /// The adapt.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="StudentDto"/>.
        /// </returns>
        protected override StudentDto Adapt(Student data)
        {
            return data;
        }

        /// <summary>
        /// The adapt.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="Student"/>.
        /// </returns>
        protected override Student Adapt(StudentDto data)
        {
            return data;
        }
    }
}
