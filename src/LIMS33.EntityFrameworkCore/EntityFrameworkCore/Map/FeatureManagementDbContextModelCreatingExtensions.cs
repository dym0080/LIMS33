using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;


namespace LIMS33.EntityFrameworkCore.Map
{
    public static class FeatureManagementDbContextModelCreatingExtensions
    {
        public static void ConfigureFeatureManagementExtensions(
            this ModelBuilder builder,
            Action<FeatureManagementModelBuilderConfigurationOptions> optionsAction = null)
        {
            var options = new FeatureManagementModelBuilderConfigurationOptions(
                LIMS33Consts.DbTablePrefixAbp,
                LIMS33Consts.DbSchemaAbp
            );

            optionsAction?.Invoke(options);

            builder.Entity<FeatureValue>(b =>
            {
                b.ToTable(options.TablePrefix + "FEATURE_VALUES", options.Schema);
                b.ConfigureByConvention();
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.Name).HasColumnName("NAME");
                b.Property(x => x.Value).HasColumnName("VALUE");
                b.Property(x => x.ProviderName).HasColumnName("PROVIDER_NAME");
                b.Property(x => x.ProviderKey).HasColumnName("PROVIDER_KEY");
            });
        }
    }
}
