using System.Linq;
using Castle.Windsor;
using MvcSample.IocInstaller;

namespace MvcSample.AngularJs.Web
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies()
        {
            var wc = new WindsorContainer();

            var installers = Dependencies.Installers;
            installers.Add(new ModuleInstaller());

            wc.Install(installers.ToArray());
        }
    }
}