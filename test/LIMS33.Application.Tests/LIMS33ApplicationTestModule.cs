using Volo.Abp.Modularity;

namespace LIMS33
{
    [DependsOn(
        typeof(LIMS33ApplicationModule),
        typeof(LIMS33DomainTestModule)
        )]
    public class LIMS33ApplicationTestModule : AbpModule
    {

    }
}