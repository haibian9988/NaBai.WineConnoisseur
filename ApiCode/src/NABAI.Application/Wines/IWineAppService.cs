using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NABAI.Wines.Dto;

namespace NABAI.Wines
{
    public interface IWineAppService : IApplicationService
    {
        Task<WineDto> Get(GetWineInput input);

        Task<PagedResultDto<WineListDto>> GetAll(GetWineListInput input);

    }
}
