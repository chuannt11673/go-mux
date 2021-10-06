using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AltSource.BrighterPath.Authorization;

namespace AltSource.BrighterPath
{
    [DependsOn(
        typeof(BrighterPathCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BrighterPathApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BrighterPathAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BrighterPathApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

