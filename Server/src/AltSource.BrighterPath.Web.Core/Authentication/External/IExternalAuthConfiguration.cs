using System.Collections.Generic;

namespace AltSource.BrighterPath.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}

