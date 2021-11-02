using System;
using System.Collections.Generic;
using System.Text;
using LIMS33.Localization;
using Volo.Abp.Application.Services;

namespace LIMS33
{
    /* Inherit your application services from this class.
     */
    public abstract class LIMS33AppService : ApplicationService
    {
        protected LIMS33AppService()
        {
            LocalizationResource = typeof(LIMS33Resource);
        }
    }
}
