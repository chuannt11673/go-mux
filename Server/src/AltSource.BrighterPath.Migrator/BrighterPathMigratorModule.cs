using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AltSource.BrighterPath.Configuration;
using AltSource.BrighterPath.EntityFrameworkCore;
using AltSource.BrighterPath.Migrator.DependencyInjection;

namespace AltSource.BrighterPath.Migrator
{
    [DependsOn(typeof(BrighterPathEntityFrameworkModule))]
    public class BrighterPathMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public BrighterPathMigratorModule(BrighterPathEntityFrameworkModule abpBrighterPathEntityFrameworkModule)
        {
            abpBrighterPathEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(BrighterPathMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                BrighterPathConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BrighterPathMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}

