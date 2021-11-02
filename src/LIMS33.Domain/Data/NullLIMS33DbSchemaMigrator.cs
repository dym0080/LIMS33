using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace LIMS33.Data
{
    /* This is used if database provider does't define
     * ILIMS33DbSchemaMigrator implementation.
     */
    public class NullLIMS33DbSchemaMigrator : ILIMS33DbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}