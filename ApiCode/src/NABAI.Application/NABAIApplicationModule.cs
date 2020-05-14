using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using NABAI.Authorization;

namespace NABAI
{
    [DependsOn(
        typeof(NABAICoreModule), 
        typeof(AbpAutoMapperModule))]
    public class NABAIApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<NABAIAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(NABAIApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
