using Abp.Authorization;
using AltSource.BrighterPath.Authorization.Roles;
using AltSource.BrighterPath.Authorization.Users;

namespace AltSource.BrighterPath.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

