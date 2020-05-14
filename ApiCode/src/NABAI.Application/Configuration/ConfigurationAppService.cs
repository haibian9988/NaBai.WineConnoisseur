using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using NABAI.Configuration.Dto;

namespace NABAI.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : NABAIAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
