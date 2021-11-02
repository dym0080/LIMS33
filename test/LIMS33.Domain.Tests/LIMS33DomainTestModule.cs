using LIMS33.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LIMS33
{
    [DependsOn(
        typeof(LIMS33EntityFrameworkCoreTestModule)
        )]
    public class LIMS33DomainTestModule : AbpModule
    {

    }
}