using System.Data.Entity;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Transport.Initialization.Context;

namespace Transport.App_Start
{
    internal class Bootstrapper
    {
        private readonly IContainer m_Container;

        internal static void Initialize()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationDbContext>()
                .As<DbContext>().InstancePerRequest();
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}