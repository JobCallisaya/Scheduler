// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseController.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The base controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.RestApi
{
    using System.ComponentModel.Design;
    using System.Net;
    using System.Web.Http;

    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.Services;

    /// <summary>
    /// The base controller.
    /// </summary>
    public abstract class BaseController<TData> : ApiController
    {
        protected IService<TData> Service { get; private set; }

        public BaseController(IService<TData> service)
        {
            this.Service = service;
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        public virtual IHttpActionResult Get()
        {
            return this.Ok(this.Service.Get());
        }

        public virtual IHttpActionResult Get(int id)
        {
            return this.Ok(this.Service.Get(id));
        }

        public virtual IHttpActionResult Create(TData data)
        {
            return this.Content(HttpStatusCode.Created, this.Service.Add(data));
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public new void Dispose()
        {   
            this.Service.Dispose();
        }
    }
}
