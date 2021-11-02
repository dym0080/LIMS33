using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using LIMS33.Data;
using Volo.Abp.DependencyInjection;

namespace LIMS33.EntityFrameworkCore
{
    public class EntityFrameworkCoreLIMS33DbSchemaMigrator
        : ILIMS33DbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreLIMS33DbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the LIMS33DbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<LIMS33DbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
