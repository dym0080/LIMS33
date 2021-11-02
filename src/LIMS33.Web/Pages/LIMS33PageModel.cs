using LIMS33.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace LIMS33.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class LIMS33PageModel : AbpPageModel
    {
        protected LIMS33PageModel()
        {
            LocalizationResourceType = typeof(LIMS33Resource);
        }
    }
}