using System.Threading.Tasks;
using Abp.Application.Services;
using AltSource.BrighterPath.Sessions.Dto;

namespace AltSource.BrighterPath.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

