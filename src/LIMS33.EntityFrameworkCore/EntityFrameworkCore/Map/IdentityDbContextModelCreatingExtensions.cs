using IdentityModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace LIMS33.EntityFrameworkCore.Map
{
    public static class IdentityDbContextModelCreatingExtensions
    {
        public static void ConfigureIdentityExtensions(
        this ModelBuilder builder,
        Action<IdentityModelBuilderConfigurationOptions> optionsAction = null)
        {
            var options = new IdentityModelBuilderConfigurationOptions(
                 LIMS33Consts.DbTablePrefixAbp,
                 LIMS33Consts.DbSchemaAbp
            );

            optionsAction?.Invoke(options);

            builder.Entity<IdentityUser>(b =>
            {
                b.ToTable(options.TablePrefix + "USERS", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");
                b.Property(x => x.UserName).HasColumnName("USER_NAME");
                b.Property(x => x.NormalizedUserName).HasColumnName("NORMALIZED_USER_NAME");
                b.Property(x => x.Name).HasColumnName("NAME");
                b.Property(x => x.Surname).HasColumnName("SUR_NAME");
                b.Property(x => x.Email).HasColumnName("EMAIL");
                b.Property(x => x.NormalizedEmail).HasColumnName("NORMALIZED_EMAIL");
                b.Property(x => x.EmailConfirmed).HasColumnName("EMAIL_CONFIRMED");
                b.Property(x => x.PasswordHash).HasColumnName("PASSWORD_HASH");
                b.Property(x => x.SecurityStamp).HasColumnName("SECURITY_STAMP");
                b.Property(x => x.IsExternal).HasColumnName("IS_EXTERNAL");
                b.Property(x => x.PhoneNumber).HasColumnName("PHONE_NUMBER");
                b.Property(x => x.PhoneNumberConfirmed).HasColumnName("PHONE_NUMBER_CONFIRMED");
                b.Property(x => x.TwoFactorEnabled).HasColumnName("TWO_FACTOR_ENABLED");
                b.Property(x => x.LockoutEnd).HasColumnName("LOCKOUT_END");
                b.Property(x => x.LockoutEnabled).HasColumnName("LOCKOUT_ENABLED");
                b.Property(x => x.AccessFailedCount).HasColumnName("ACCESS_FAILED_COUNT");

                b.Property(x => x.ExtraProperties).HasColumnName("EXTRA_PROPERTIES");
                b.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
                b.Property(x => x.CreationTime).HasColumnName("CREATION_TIME").HasColumnType("DATE");
                b.Property(x => x.CreatorId).HasColumnName("CREATOR_ID");
                b.Property(x => x.LastModificationTime).HasColumnName("LAST_MODIFICATION_TIME").HasColumnType("DATE");
                b.Property(x => x.LastModifierId).HasColumnName("LAST_MODIFIER_ID");
                b.Property(x => x.IsDeleted).HasColumnName("IS_DELETED");
                b.Property(x => x.DeleterId).HasColumnName("DELETER_ID");
                b.Property(x => x.DeletionTime).HasColumnName("DELETION_TIME").HasColumnType("DATE");
            });

            builder.Entity<IdentityRole>(b =>
            {
                b.ToTable(options.TablePrefix + "ROLES", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");
                b.Property(x => x.Name).HasColumnName("NAME");
                b.Property(x => x.NormalizedName).HasColumnName("NORMALIZED_NAME");
                b.Property(x => x.IsDefault).HasColumnName("IS_DEFAULT");
                b.Property(x => x.IsStatic).HasColumnName("IS_STATIC");
                b.Property(x => x.IsPublic).HasColumnName("IS_PUBLIC");
                b.Property(x => x.ExtraProperties).HasColumnName("EXTRA_PROPERTIES");
                b.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
            });

            builder.Entity<IdentityUserRole>(b =>
            {
                b.ToTable(options.TablePrefix + "USER_ROLE", options.Schema);
                b.Property(x => x.UserId).HasColumnName("USER_ID");
                b.Property(x => x.RoleId).HasColumnName("ROLE_ID");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");

            });

            builder.Entity<IdentityUserToken>(b =>
            {
                b.ToTable(options.TablePrefix + "USER_TOKEN", options.Schema);
                b.Property(x => x.UserId).HasColumnName("USER_ID");
                b.Property(x => x.LoginProvider).HasColumnName("LOGIN_PROVIDER");
                b.Property(x => x.Name).HasColumnName("NAME");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");
                b.Property(x => x.Value).HasColumnName("VALUE");

            });

            builder.Entity<IdentityUserClaim>(b =>
            {
                b.ToTable(options.TablePrefix + "USER_CLAIM", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.UserId).HasColumnName("USER_ID");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");
                b.Property(x => x.ClaimType).HasColumnName("CLAIM_TYPE");
                b.Property(x => x.ClaimValue).HasColumnName("CLAIM_VALUE");
            });

            builder.Entity<IdentityRoleClaim>(b =>
            {
                b.ToTable(options.TablePrefix + "ROLE_CLAIM", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.RoleId).HasColumnName("ROLE_ID");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");
                b.Property(x => x.ClaimType).HasColumnName("CLAIM_TYPE");
                b.Property(x => x.ClaimValue).HasColumnName("CLAIM_VALUE");
            });

            builder.Entity<IdentityClaimType>(b =>
            {
                b.ToTable(options.TablePrefix + "CLAIM_TYPES", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.Name).HasColumnName("NAME");
                b.Property(x => x.Required).HasColumnName("REQUIRED");
                b.Property(x => x.IsStatic).HasColumnName("IS_STATIC");
                b.Property(x => x.Regex).HasColumnName("REGEX");
                b.Property(x => x.RegexDescription).HasColumnName("REGEX_DESCRIPTION");
                b.Property(x => x.Description).HasColumnName("DESCRIPTION");
                b.Property(x => x.ValueType).HasColumnName("VALUE_TYPE");
                b.Property(x => x.ExtraProperties).HasColumnName("EXTRA_PROPERTIES");
                b.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
            });

            builder.Entity<IdentitySecurityLog>(b =>
            {
                b.ToTable(options.TablePrefix + "SECURITY_LOGS", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");
                b.Property(x => x.ApplicationName).HasColumnName("APPLICATION_NAME");
                b.Property(x => x.Identity).HasColumnName("IDENTITY");
                b.Property(x => x.Action).HasColumnName("ACTION");
                b.Property(x => x.UserId).HasColumnName("USER_ID");
                b.Property(x => x.UserName).HasColumnName("USER_NAME");
                b.Property(x => x.TenantName).HasColumnName("TENANT_NAME");
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.CorrelationId).HasColumnName("CORRELATION_ID");
                b.Property(x => x.ClientIpAddress).HasColumnName("CLIENT_IP_ADDRESS");
                b.Property(x => x.BrowserInfo).HasColumnName("BROWSER_INFO");
                b.Property(x => x.CreationTime).HasColumnName("CREATION_TIME");
                b.Property(x => x.ExtraProperties).HasColumnName("EXTRA_PROPERTIES");
                b.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
            });

            builder.Entity<IdentityLinkUser>(b =>
            {
                b.ToTable(options.TablePrefix + "LINK_USERS", options.Schema);
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.SourceUserId).HasColumnName("SOURCE_USER_ID");
                b.Property(x => x.SourceTenantId).HasColumnName("SOURCE_TENANT_ID");
                b.Property(x => x.TargetUserId).HasColumnName("TARGET_USER_ID");
                b.Property(x => x.TargetTenantId).HasColumnName("TARGET_TENANT_ID");
            });

            builder.Entity<IdentityUserLogin>(b =>
            {
                b.ToTable(options.TablePrefix + "USER_LOGINS", options.Schema);
                b.Property(x => x.UserId).HasColumnName("USER_ID");
                b.Property(x => x.LoginProvider).HasColumnName("LOGIN_PROVIDER");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");
                b.Property(x => x.ProviderKey).HasColumnName("PROVIDER_KEY");
                b.Property(x => x.ProviderDisplayName).HasColumnName("PROVIDER_DISPLAY_NAME");
            });

            builder.Entity<OrganizationUnit>(b =>
            {
                b.ToTable(options.TablePrefix + "ORGANIZATION_UNITS", options.Schema);
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");
                b.Property(x => x.ParentId).HasColumnName("PARENT_ID");
                b.Property(x => x.Code).HasColumnName("CODE");
                b.Property(x => x.DisplayName).HasColumnName("DISPLAY_NAME");

                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.ExtraProperties).HasColumnName("EXTRA_PROPERTIES");
                b.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
                b.Property(x => x.CreationTime).HasColumnName("CREATION_TIME").HasColumnType("DATE");
                b.Property(x => x.CreatorId).HasColumnName("CREATOR_ID");
                b.Property(x => x.LastModificationTime).HasColumnName("LAST_MODIFICATION_TIME").HasColumnType("DATE");
                b.Property(x => x.LastModifierId).HasColumnName("LAST_MODIFIER_ID");
                b.Property(x => x.IsDeleted).HasColumnName("IS_DELETED");
                b.Property(x => x.DeleterId).HasColumnName("DELETER_ID");
                b.Property(x => x.DeletionTime).HasColumnName("DELETION_TIME").HasColumnType("DATE");
            });

            builder.Entity<OrganizationUnitRole>(b =>
            {
                b.ToTable(options.TablePrefix + "ORGANIZATION_UNIT_ROLES", options.Schema);
                b.Property(x => x.RoleId).HasColumnName("ROLE_ID");
                b.Property(x => x.OrganizationUnitId).HasColumnName("ORGANIZATION_UNIT_ID");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");
                b.Property(x => x.CreationTime).HasColumnName("CREATION_TIME");
                b.Property(x => x.CreatorId).HasColumnName("CREATOR_ID");
            });

            builder.Entity<IdentityUserOrganizationUnit>(b =>
            {
                b.ToTable(options.TablePrefix + "USER_ORGANIZATION_UNIT", options.Schema);
                b.Property(x => x.UserId).HasColumnName("USER_ID");
                b.Property(x => x.OrganizationUnitId).HasColumnName("ORGANIZATION_UNIT_ID");
                b.Property(x => x.TenantId).HasColumnName("TENANT_ID");
                b.Property(x => x.CreationTime).HasColumnName("CREATION_TIME");
                b.Property(x => x.CreatorId).HasColumnName("CREATOR_ID");
            });

        }
    }
}
