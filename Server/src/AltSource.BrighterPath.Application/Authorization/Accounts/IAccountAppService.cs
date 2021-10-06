using System.Threading.Tasks;
using Abp.Application.Services;
using AltSource.BrighterPath.Authorization.Accounts.Dto;

namespace AltSource.BrighterPath.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

