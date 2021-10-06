using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AltSource.BrighterPath.Configuration;

namespace AltSource.BrighterPath.Web.Host.Startup
{
    [DependsOn(
       typeof(BrighterPathWebCoreModule))]
    public class BrighterPathWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BrighterPathWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BrighterPathWebHostModule).GetAssembly());
        }
    }
}

