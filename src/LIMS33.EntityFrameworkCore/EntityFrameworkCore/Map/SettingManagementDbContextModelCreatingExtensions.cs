using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace LIMS33.EntityFrameworkCore.Map
{
    public static class SettingManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureSettingManagementExtensions(
            this ModelBuilder builder,
            Action<SettingManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            var options = new SettingManagementModelBuilderConfigurationOptions(
                LIMS33Consts.DbTablePrefixAbp,
                LIMS33Consts.DbSchemaAbp
            );

            optionsAction?.Invoke(options);

            builder.Entity<Setting>(b =>
            {
                b.ToTable(options.TablePrefix + "SETTINGS", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.Name).HasColumnName("NAME").HasMaxLength(50);
                b.Property(x => x.Value).HasColumnName("VALUE").HasMaxLength(200);
                b.Property(x => x.ProviderName).HasColumnName("PROVIDER_NAME");
                b.Property(x => x.ProviderKey).HasColumnName("PROVIDER_KEY");
            });

        }
    }
}
