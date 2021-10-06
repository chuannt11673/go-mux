using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AltSource.BrighterPath.Controllers
{
    public abstract class BrighterPathControllerBase: AbpController
    {
        protected BrighterPathControllerBase()
        {
            LocalizationSourceName = BrighterPathConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

