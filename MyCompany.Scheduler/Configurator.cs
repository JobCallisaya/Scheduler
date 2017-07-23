// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Configurator.cs" company="MyCompany">
//   Copyright (c) MyCompany.
// </copyright>
// <summary>
//   Defines the Startup type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MyCompany.Scheduler
{
    using System.Configuration;
    using System.Web.Http;
    using System.Web.Http.Filters;

    using Microsoft.Practices.Unity;

    using MyCompany.Scheduler.DataAccess;
    using MyCompany.Scheduler.DataAccess.Common;
    using MyCompany.Scheduler.DataAccess.Memory;
    using MyCompany.Scheduler.DataAccess.SqlServer;
    using MyCompany.Scheduler.RestApi;
    using MyCompany.Scheduler.RestApi.ExceptionHandling;
    using MyCompany.Scheduler.Services;

    using Owin;

    using Swashbuckle.Application;

    /// <summary>
    /// Configures Web API. This class is specified as a type parameter in the WebApp.Start method.
    /// </summary>
    public class Configurator
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        /// <param name="appBuilder">
        /// The application builder.
        /// </param>
        public void Configuration(IAppBuilder appBuilder) 
        { 
            // This loads the controllers in the Rest assembly.
            var baseController = typeof(BaseController<int, int>);

            var httpConfiguration = new HttpConfiguration();
            
            this.ConfigureDependecyInjection(httpConfiguration);
            this.ConfigureFilters(httpConfiguration.Filters);
            this.ConfigureSwagger(httpConfiguration);

            httpConfiguration.MapHttpAttributeRoutes();
            appBuilder.UseWebApi(httpConfiguration);
        }

        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="httpConfiguration">
        /// The http Configuration.
        /// </param>
        public void ConfigureDependecyInjection(HttpConfiguration httpConfiguration)
        {
            var connectionSettings = ConfigurationManager.ConnectionStrings["SchedulerConnection"];

            var unityContainer = new UnityContainer();

            unityContainer.RegisterType<IUnitOfWork, AdoUnitOfWork>(
                new HierarchicalLifetimeManager(),
                new InjectionConstructor(new DbConnectionFactory().CreateConnection(connectionSettings)));

            unityContainer.RegisterType<StudentController>(new InjectionConstructor(new ResolvedParameter<StudentService>(), new ResolvedParameter<IUnitOfWork>()));
            unityContainer.RegisterType<ClassesController>(new InjectionConstructor(new ResolvedParameter<ClassService>(), new ResolvedParameter<IUnitOfWork>()));

            httpConfiguration.DependencyResolver = new UnityResolver(unityContainer);
        }

        /// <summary>
        /// The configure filters.
        /// </summary>
        /// <param name="filters">
        /// The filters.
        /// </param>
        public void ConfigureFilters(HttpFilterCollection filters)
        {
            filters.Add(new ExceptionHandler());
        }

        /// <summary>
        /// The configur swagger.
        /// </summary>
        /// <param name="httpConfiguration">
        /// The http configuration.
        /// </param>
        public void ConfigureSwagger(HttpConfiguration httpConfiguration)
        {
            httpConfiguration
                .EnableSwagger(c => c.SingleApiVersion("v1", "A title for your API"))
                .EnableSwaggerUi(); 
        }
    } 
}