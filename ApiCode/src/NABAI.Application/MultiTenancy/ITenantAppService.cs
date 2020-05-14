using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NABAI.MultiTenancy.Dto;

namespace NABAI.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

