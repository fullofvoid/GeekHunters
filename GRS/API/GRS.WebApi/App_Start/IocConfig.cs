using Autofac;
using Autofac.Integration.WebApi;
using GRS.DataAccess;
using GRS.Repository;
using GRS.WebApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace GRS.WebApi
{
    public class IocConfig
    {

        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<CandidateServices>().AsSelf().InstancePerRequest();
            builder.RegisterType<CandidateRepository>().As<ICandidateRepository>().InstancePerRequest();
            builder.RegisterType<CandidateEntities>().As<ICandidateEntities>().InstancePerDependency();
            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            DBContextResolver.Config(container);

        }
    }
}