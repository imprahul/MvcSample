using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MvcSample.AngularJs.Web.Infrastructure;

namespace MvcSample.AngularJs.Web
{
    public class ModuleInstaller : IWindsorInstaller
    {

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().Where(Component.IsCastleComponent));
            container.Register(Component.For<WindsorControllerFactory>());

            container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient()
                .Configure(x => x.Named(x.Implementation.FullName)));

            var controllerFactory = container.Resolve<WindsorControllerFactory>();
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}