using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NABAI.Configuration;

namespace NABAI.Web.Host.Startup
{
    [DependsOn(
       typeof(NABAIWebCoreModule))]
    public class NABAIWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public NABAIWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(NABAIWebHostModule).GetAssembly());
        }
    }
}
