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
    using System.Web.Http;

    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.Services;

    /// <summary>
    /// The Class controller.
    /// </summary>
    [RoutePrefix("api")]
    [Route("")]
    public class ClassesController : BaseController<Class>
    {
        public ClassesController(IService<Class> service)
            : base(service)
        {
        }

        [HttpPost]
        [Route("classes")]
        public override IHttpActionResult Create(Class Class)
        {
            return base.Create(Class);
        }

        [HttpPut]
        [Route("classes/{id}")]
        public override IHttpActionResult Update(int id, Class Class)
        {
            return base.Update(id, Class);
        }

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
    }
}
