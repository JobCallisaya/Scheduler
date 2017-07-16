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
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;

    using MyCompany.Scheduler.DataAccess;
    using MyCompany.Scheduler.Services;

    /// <summary>
    /// The base controller.
    /// </summary>
    /// <typeparam name="TData">
    /// </typeparam>
    /// <typeparam name="TDataDto">
    /// </typeparam>
    public abstract class BaseController<TData, TDataDto> : ApiController
    {
        /// <summary>
        /// Gets the service.
        /// </summary>
        protected IService<TData> Service { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController{TData,TDataDto}"/> class.
        /// </summary>
        /// <param name="service">
        /// The service.
        /// </param>
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
            return this.Ok(this.Service.Get().Select(data => this.Adapt(data)));
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
        public virtual IHttpActionResult Get(List<CustomExpression> filter)
        {
            return this.Ok(this.Service.Get(filter).Select(data => this.Adapt(data)));
        }

        /// <summary>
        /// The get.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        public virtual IHttpActionResult Get(int id)
        {
            return this.Ok(this.Adapt(this.Service.Get(id)));
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        public virtual IHttpActionResult Create(TDataDto data)
        {
            return this.Content(HttpStatusCode.Created, this.Adapt(this.Service.Add(this.Adapt(data))));
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="IHttpActionResult"/>.
        /// </returns>
        public virtual IHttpActionResult Update(int id, TDataDto data)
        {
            return this.Ok(this.Adapt(this.Service.Update(id, Adapt(data))));
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
        public virtual IHttpActionResult Delete(int id)
        {
            this.Service.Remove(id);
            return this.Ok();
        }
        
        /// <summary>
        /// The dispose.
        /// </summary>
        public new void Dispose()
        {   
            this.Service.Dispose();
        }

        /// <summary>
        /// The adapt.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="TDataDto"/>.
        /// </returns>
        protected abstract TDataDto Adapt(TData data);

        /// <summary>
        /// The adapt.
        /// </summary>
        /// <param name="data">
        /// The data.
        /// </param>
        /// <returns>
        /// The <see cref="TData"/>.
        /// </returns>
        protected abstract TData Adapt(TDataDto data);
    }
}
