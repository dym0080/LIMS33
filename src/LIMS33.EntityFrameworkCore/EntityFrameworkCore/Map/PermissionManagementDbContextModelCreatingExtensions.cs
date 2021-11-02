using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;

namespace LIMS33.EntityFrameworkCore.Map
{
    public static class PermissionManagementDbContextModelCreatingExtensions
    {
        public static void ConfigurePermissionManagementExtensions(
            this ModelBuilder builder,
            Action<AbpPermissionManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            var options = new AbpPermissionManagementModelBuilderConfigurationOptions(
                LIMS33Consts.DbTablePrefixAbp,
                LIMS33Consts.DbSchemaAbp
            );

            optionsAction?.Invoke(options);

            builder.Entity<PermissionGrant>(b =>
            {
                b.ToTable(options.TablePrefix + "PERMISSION_GRANTS", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");
                b.Property(x => x.Name).HasColumnName("NAME");
                b.Property(x => x.ProviderName).HasColumnName("PROVIDER_NAME");
                b.Property(x => x.ProviderKey).HasColumnName("PROVIDER_KEY");
            });

        }
    }
}
