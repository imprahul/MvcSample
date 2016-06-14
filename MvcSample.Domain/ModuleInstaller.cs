using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace MvcSample.Domain
{
    public class ModuleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //TODO: Uncomment the following lines if using the database
            //var configuration = GetNHibernateConfiguration();
            //container.Register(Component.For<ISessionFactory>().Instance(configuration.BuildSessionFactory()));
            container.Register(Classes.FromThisAssembly().Where(Component.IsCastleComponent).LifestyleTransient());
        }

        private Configuration GetNHibernateConfiguration()
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(x => x.FromConnectionStringWithKey("AngularSampleDatabase")))
                .CurrentSessionContext("web")
                .Mappings(m => m.FluentMappings.AddFromAssembly(GetType().Assembly))
                .BuildConfiguration();
            return configuration;
        }
    }
}