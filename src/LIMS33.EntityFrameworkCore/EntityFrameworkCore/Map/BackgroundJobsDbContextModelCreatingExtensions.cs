using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LIMS33.EntityFrameworkCore.Map
{
    public static class BackgroundJobsDbContextModelCreatingExtensions
    {
        public static void ConfigureBackgroundJobsExtensions(
            this ModelBuilder builder,
            Action<BackgroundJobsModelBuilderConfigurationOptions> optionsAction = null)
        {
            var options = new BackgroundJobsModelBuilderConfigurationOptions(
                LIMS33Consts.DbTablePrefixAbp,
                LIMS33Consts.DbSchemaAbp
            );

            optionsAction?.Invoke(options);

            builder.Entity<BackgroundJobRecord>(b =>
            {
                b.ToTable(options.TablePrefix + "BACKGROUND_JOBS", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.JobName).HasColumnName("JOB_NAME").IsRequired().HasMaxLength(128);
                b.Property(x => x.JobArgs).HasColumnName("JOB_ARGS");
                b.Property(x => x.TryCount).HasColumnName("TRY_COUNT");
                b.Property(x => x.CreationTime).HasColumnName("CREATION_TIME").HasColumnType("DATE");
                b.Property(x => x.NextTryTime).HasColumnName("NEXT_TRY_TIME");
                b.Property(x => x.LastTryTime).HasColumnName("LAST_TRY_TIME");
                b.Property(x => x.IsAbandoned).HasColumnName("IS_ABANDONED");
                b.Property(x => x.Priority).HasColumnName("PRIORITY");
                b.Property(x => x.ExtraProperties).HasColumnName("EXTRA_PROPERTIES").HasMaxLength(200).HasColumnType("VARCHAR2");
                b.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
            });

        }
    }
}
