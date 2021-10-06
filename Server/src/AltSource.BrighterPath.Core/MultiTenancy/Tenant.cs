using Abp.MultiTenancy;
using AltSource.BrighterPath.Authorization.Users;

namespace AltSource.BrighterPath.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}

