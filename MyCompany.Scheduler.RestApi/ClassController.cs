// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassesController.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The class controller.
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
    /// The Class controller.
    /// </summary>
    [RoutePrefix("api")]
    [Route("")]
    public class ClassesController : BaseController<Class, ClassDto>
    {
        public ClassesController(IService<Class> service)
            : base(service)
        {   
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="Class">
        /// The class.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpPost]
        [Route("classes")]
        public override IHttpActionResult Create(ClassDto Class)
        {
            return base.Create(Class);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="Class">
        /// The class.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpPut]
        [Route("classes/{id}")]
        public override IHttpActionResult Update(int id, ClassDto Class)
        {
            return base.Update(id, Class);
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
        [Route("classes/{id}")]
        public override IHttpActionResult Delete(int id)
        {
            return base.Delete(id);
        }

        /// <summary>
        /// The get classes.
        /// </summary>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpGet]
        [Route("classes")]
        public override IHttpActionResult Get()
        {
            return base.Get();
        }

        /// <summary>
        /// The get students.
        /// </summary>
        /// <param name="classId">
        /// The class id.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpGet]
        [Route("classes/{classId}/students")]
        public IHttpActionResult GetStudents(int classId)
        {
            var classService = (ClassService)this.Service;
            return this.Ok(classService.GetStudents(classId).Select(student => (StudentDto)student));
        }

        /// <summary>
        /// The add student to class.
        /// </summary>
        /// <param name="classId">
        /// The class id.
        /// </param>
        /// <param name="studentId">
        /// The student id.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        [HttpPost]
        [Route("classes/{classId}/students")]
        public IHttpActionResult AddStudentToClass(int classId, [FromBody] int studentId)
        {
            var classService = (ClassService)this.Service;
            classService.AddStudentToClass(classId, studentId);
            return this.Ok();
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
        [Route("classes/filter")]
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
        protected override ClassDto Adapt(Class data)
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
        protected override Class Adapt(ClassDto data)
        {
            return data;
        }
    }
}
