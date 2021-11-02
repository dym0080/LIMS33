using LIMS33.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace LIMS33.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(LIMS33EntityFrameworkCoreModule),
        typeof(LIMS33ApplicationContractsModule)
        )]
    public class LIMS33DbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
