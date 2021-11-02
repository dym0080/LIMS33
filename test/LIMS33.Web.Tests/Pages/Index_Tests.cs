using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace LIMS33.Pages
{
    public class Index_Tests : LIMS33WebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
