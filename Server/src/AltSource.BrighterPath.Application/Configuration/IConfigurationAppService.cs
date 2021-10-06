using System.Threading.Tasks;
using AltSource.BrighterPath.Configuration.Dto;

namespace AltSource.BrighterPath.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

