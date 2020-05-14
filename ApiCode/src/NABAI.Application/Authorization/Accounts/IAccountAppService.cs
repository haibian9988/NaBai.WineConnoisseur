using System.Threading.Tasks;
using Abp.Application.Services;
using NABAI.Authorization.Accounts.Dto;

namespace NABAI.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
