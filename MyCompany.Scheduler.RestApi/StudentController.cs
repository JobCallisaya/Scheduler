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
        /// <summary>
        /// Initializes a new instance of the <see cref="StudentController"/> class.
        /// </summary>
        /// <param name="service">
        /// The service.
        /// </param>
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

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpPost]
        [Route("students/filter")]
        public override IHttpActionResult Get(List<CustomExpression> filter)
        {
            return base.Get(filter);
        }

        /// <summary>
        /// The get classes.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpGet]
        [Route("students/{id}/classes")]
        public IHttpActionResult GetClasses(int id)
        {
            var studentService = (StudentService)this.Service;
            return this.Ok(studentService.GetClasses(id).Select(student => (ClassDto)student));
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="student">
        /// The student.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpPost]
        [Route("students")]
        public override IHttpActionResult Create(StudentDto student)
        {
            return base.Create(student);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="student">
        /// The student.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpPut]
        [Route("students/{id}")]
        public override IHttpActionResult Update(int id, StudentDto student)
        {
            return base.Update(id, student);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpDelete]
        [Route("students/{id}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
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
