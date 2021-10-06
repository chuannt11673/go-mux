using System.Threading.Tasks;
using AltSource.BrighterPath.Models.TokenAuth;
using AltSource.BrighterPath.Web.Controllers;
using Shouldly;
using Xunit;

namespace AltSource.BrighterPath.Web.Tests.Controllers
{
    public class HomeController_Tests: BrighterPathWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
