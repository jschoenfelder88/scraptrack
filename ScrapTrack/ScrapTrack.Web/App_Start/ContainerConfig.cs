using Autofac;
using Autofac.Integration.Mvc;
using ScrapTrack.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScrapTrack.Web
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<InMemoryItemData>()
                .As<IItemData>()
                .SingleInstance();
            builder.RegisterType<InMemoryVolunteerData>()
                .As<IVolunteerData>()
                .SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}