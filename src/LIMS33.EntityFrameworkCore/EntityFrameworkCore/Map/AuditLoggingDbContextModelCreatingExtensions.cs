using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AuditLogging;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity.EntityFrameworkCore;


namespace LIMS33.EntityFrameworkCore.Map
{
    public static class AuditLoggingDbContextModelCreatingExtensions
    {
        public static void ConfigureAuditLoggingExtensions(
            this ModelBuilder builder,
            Action<AbpAuditLoggingModelBuilderConfigurationOptions> optionsAction = null)
        {
            var options = new AbpAuditLoggingModelBuilderConfigurationOptions(
                LIMS33Consts.DbTablePrefixAbp,
                LIMS33Consts.DbSchemaAbp
            );

            optionsAction?.Invoke(options);

            builder.Entity<AuditLog>(b =>
            {
                b.ToTable(options.TablePrefix + "AUDIT_LOGS", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.ApplicationName).HasColumnName("APPLICATION_NAME");
                b.Property(x => x.ClientIpAddress).HasColumnName("CLIENT_IP_ADDRESS");
                b.Property(x => x.ClientName).HasColumnName("CLIENT_NAME");
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.CorrelationId).HasColumnName("CORRELATION_ID");
                b.Property(x => x.BrowserInfo).HasColumnName("BROWSER_INFO");
                b.Property(x => x.HttpMethod).HasColumnName("HTTP_METHOD");
                b.Property(x => x.Url).HasColumnName("URL");
                b.Property(x => x.HttpStatusCode).HasColumnName("HTTP_STATUS_CODE");

                b.Property(x => x.Comments).HasColumnName("COMMENTS");
                b.Property(x => x.ExecutionDuration).HasColumnName("EXECUTION_DURATION");
                b.Property(x => x.ImpersonatorTenantId).HasColumnName("IMPERSONATOR_TENANT_ID");
                b.Property(x => x.ImpersonatorUserId).HasColumnName("IMPERSONATOR_USER_ID");
                b.Property(x => x.UserId).HasColumnName("USER_ID");
                b.Property(x => x.UserName).HasColumnName("USER_NAME");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");

                b.Property(x => x.TenantName).HasColumnName("TENANT_NAME");
                b.Property(x => x.ExecutionTime).HasColumnName("EXECUTION_TIME");
                b.Property(x => x.Exceptions).HasColumnName("EXCEPTIONS");
                b.Property(x => x.ExtraProperties).HasColumnName("EXTRAPROPERTIES");
                b.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");

            });

            builder.Entity<AuditLogAction>(b =>
            {
                b.ToTable(options.TablePrefix + "AUDIT_LOG_ACTIONS", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.AuditLogId).HasColumnName("AUDIT_LOG_ID");
                b.Property(x => x.ExecutionDuration).HasColumnName("EXECUTION_DURATION");
                b.Property(x => x.ExecutionTime).HasColumnName("EXECUTION_TIME");
                b.Property(x => x.ExtraProperties).HasColumnName("EXTRA_PROPERTIES");
                b.Property(x => x.MethodName).HasColumnName("METHOD_NAME");
                b.Property(x => x.Parameters).HasColumnName("PARAMETERS");
                b.Property(x => x.ServiceName).HasColumnName("SERVICE_NAME");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");

            });

            builder.Entity<EntityChange>(b =>
            {
                b.ToTable(options.TablePrefix + "ENTITY_CHANGES", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.AuditLogId).HasColumnName("AUDIT_LOG_ID");
                b.Property(x => x.ChangeTime).HasColumnName("CHANGE_TIME");
                b.Property(x => x.ChangeType).HasColumnName("CHANGE_TYPE");
                b.Property(x => x.EntityId).HasColumnName("ENTITY_ID");
                b.Property(x => x.EntityTenantId).HasColumnName("ENTITY_TENANT_ID");
                b.Property(x => x.EntityTypeFullName).HasColumnName("ENTITY_TYPE_FULL_NAME");
                b.Property(x => x.ExtraProperties).HasColumnName("EXTRA_PROPERTIES");
                //b.Property(x => x.PropertyChanges).HasColumnName("PROPERTY_CHANGES");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");

            });

            builder.Entity<EntityPropertyChange>(b =>
            {
                b.ToTable(options.TablePrefix + "ENTITY_PROPERTY_CHANGES", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.EntityChangeId).HasColumnName("ENTITY_CHANGE_ID");
                b.Property(x => x.NewValue).HasColumnName("NEW_VALUE");
                b.Property(x => x.OriginalValue).HasColumnName("ORIGINAL_VALUE");
                b.Property(x => x.PropertyName).HasColumnName("PROPERTY_NAME");
                b.Property(x => x.PropertyTypeFullName).HasColumnName("PROPERTY_TYPE_FULL_NAME");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");

            });

        }
    }
}
