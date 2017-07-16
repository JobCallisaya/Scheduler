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
    using System.Web.Http;

    using Microsoft.Practices.Unity;

    using MyCompany.Scheduler.Data;
    using MyCompany.Scheduler.DataAccess;
    using MyCompany.Scheduler.DataAccess.Memory;
    using MyCompany.Scheduler.RestApi;
    using MyCompany.Scheduler.Services;

    using Owin;

    /// <summary>
    /// Configures Web API. This class is specified as a type parameter in the WebApp.Start method.
    /// </summary>
    public class Configurator
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public static void Register(HttpConfiguration config)
        {
            var unityContainer = new UnityContainer();

            unityContainer.RegisterType<IUnitOfWork, MemoryUnitOfWork>(new HierarchicalLifetimeManager());
            unityContainer.RegisterType<StudentController>(
                new InjectionConstructor(new ResolvedParameter<StudentService>()));
            unityContainer.RegisterType<ClassesController>(
                new InjectionConstructor(new ResolvedParameter<ClassService>()));

            config.DependencyResolver = new UnityResolver(unityContainer);
        }

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
            Register(httpConfiguration);
            httpConfiguration.MapHttpAttributeRoutes();
            appBuilder.UseWebApi(httpConfiguration);
        }
    } 
}