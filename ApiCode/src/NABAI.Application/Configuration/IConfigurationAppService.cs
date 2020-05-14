using System.Threading.Tasks;
using NABAI.Configuration.Dto;

namespace NABAI.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
