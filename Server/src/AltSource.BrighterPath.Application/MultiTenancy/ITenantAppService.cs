using Abp.Application.Services;
using AltSource.BrighterPath.MultiTenancy.Dto;

namespace AltSource.BrighterPath.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


