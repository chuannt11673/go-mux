using Abp.AutoMapper;
using AltSource.BrighterPath.Authentication.External;

namespace AltSource.BrighterPath.Models.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}

