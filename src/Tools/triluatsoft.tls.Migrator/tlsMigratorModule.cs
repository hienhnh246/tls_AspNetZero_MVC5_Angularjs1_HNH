using System.Data.Entity;
using System.Reflection;
using Abp.Events.Bus;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using triluatsoft.tls.EntityFramework;

namespace triluatsoft.tls.Migrator
{
    [DependsOn(typeof(tlsDataModule))]
    public class tlsMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<tlsDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(typeof(IEventBus), () =>
            {
                IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                );
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}