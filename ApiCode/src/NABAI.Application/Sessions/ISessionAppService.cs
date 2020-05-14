using System.Threading.Tasks;
using Abp.Application.Services;
using NABAI.Sessions.Dto;

namespace NABAI.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
