using LIMS33.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LIMS33.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class LIMS33Controller : AbpController
    {
        protected LIMS33Controller()
        {
            LocalizationResource = typeof(LIMS33Resource);
        }
    }
}