using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace LIMS33.Web
{
    [Dependency(ReplaceServices = true)]
    public class LIMS33BrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "LIMS33";
    }
}
