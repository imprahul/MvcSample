using System.Collections.Generic;
using Castle.MicroKernel.Registration;

namespace MvcSample.IocInstaller
{
    public static class Dependencies
    {
        public static IList<IWindsorInstaller> Installers
        {
            get
            {
                return new List<IWindsorInstaller>()
                {
                    new BusinessServices.ModuleInstaller(),
                    new Domain.ModuleInstaller(),
                };
            }
        }
    }
}