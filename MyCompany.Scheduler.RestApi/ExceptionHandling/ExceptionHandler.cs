// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExceptionHandler.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   The exception handler.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler.RestApi.ExceptionHandling
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Filters;

    /// <summary>
    /// The exception handler.
    /// </summary>
    public class ExceptionHandler : ExceptionFilterAttribute
    {
        /// <summary>
        /// The on exception.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <exception cref="HttpResponseException">
        /// When exception is thrown.
        /// </exception>
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is ArgumentException)
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(HttpStatusCode.BadRequest)
                        {
                            Content =
                                new StringContent("Incorrect argument"),
                        });
            }

            // Here should handled the different exceptions
        }
    }
}
