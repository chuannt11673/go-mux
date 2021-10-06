using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AltSource.BrighterPath.EntityFrameworkCore;
using AltSource.BrighterPath.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AltSource.BrighterPath.Web.Tests
{
    [DependsOn(
        typeof(BrighterPathWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class BrighterPathWebTestModule : AbpModule
    {
        public BrighterPathWebTestModule(BrighterPathEntityFrameworkModule abpBrighterPathEntityFrameworkModule)
        {
            abpBrighterPathEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BrighterPathWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(BrighterPathWebMvcModule).Assembly);
        }
    }
}
