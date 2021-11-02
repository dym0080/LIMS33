using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace LIMS33.EntityFrameworkCore.Map
{
    public static class TenantManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureTenantManagementExtensions(
            this ModelBuilder builder,
            Action<AbpTenantManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            var options = new AbpTenantManagementModelBuilderConfigurationOptions(
                LIMS33Consts.DbTablePrefixAbp,
                LIMS33Consts.DbSchemaAbp
            );

            optionsAction?.Invoke(options);

            builder.Entity<Tenant>(b =>
            {
                b.ToTable(options.TablePrefix + "TENANTS", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.Name).HasColumnName("NAME");
                b.Property(x => x.ExtraProperties).HasColumnName("EXTRA_PROPERTIES");
                b.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
                b.Property(x => x.CreationTime).HasColumnName("CREATION_TIME");
                b.Property(x => x.CreatorId).HasColumnName("CREATOR_ID");
                b.Property(x => x.LastModificationTime).HasColumnName("LAST_MODIFICATION_TIME");
                b.Property(x => x.LastModifierId).HasColumnName("LAST_MODIFIER_ID");
                b.Property(x => x.IsDeleted).HasColumnName("IS_DELETED");
                b.Property(x => x.DeleterId).HasColumnName("DELETER_ID");
                b.Property(x => x.DeletionTime).HasColumnName("DELETION_TIME");
            });

            builder.Entity<TenantConnectionString>(b =>
            {
                b.ToTable(options.TablePrefix + "TENANT_CONNECTION_STRING", options.Schema);
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");
                b.Property(x => x.Name).HasColumnName("NAME");
                b.Property(x => x.Value).HasColumnName("VALUE");
            });

        }
    }
}
