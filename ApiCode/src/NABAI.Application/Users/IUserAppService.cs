using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NABAI.Roles.Dto;
using NABAI.Users.Dto;

namespace NABAI.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
