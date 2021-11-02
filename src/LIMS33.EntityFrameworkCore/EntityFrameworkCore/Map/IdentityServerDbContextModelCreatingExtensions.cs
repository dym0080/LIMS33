using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.IdentityServer;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.ApiScopes;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.Devices;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.IdentityServer.Grants;
using Volo.Abp.IdentityServer.IdentityResources;

namespace LIMS33.EntityFrameworkCore.Map
{
    public static class IdentityServerDbContextModelCreatingExtensions
    {
        public static void ConfigureIdentityServerExtensions(
           this ModelBuilder builder,
        Action<IdentityServerModelBuilderConfigurationOptions> optionsAction = null)
        {
            var options = new IdentityServerModelBuilderConfigurationOptions(
                 LIMS33Consts.DbTablePrefixAbpIdentityServer,
                 LIMS33Consts.DbSchemaAbpIdentityServer
            );

            optionsAction?.Invoke(options);

            #region Client

            builder.Entity<Client>(b =>
            {
                b.ToTable(options.TablePrefix + "CLIENT", options.Schema);

                b.ConfigureByConvention();

                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.ClientName).HasColumnName("CLIENT_NAME");
                b.Property(x => x.Description).HasColumnName("DESCRIPTION");
                b.Property(x => x.ClientUri).HasColumnName("CLIENT_URI");
                b.Property(x => x.LogoUri).HasColumnName("LOGO_URI");
                b.Property(x => x.Enabled).HasColumnName("ENABLED");
                b.Property(x => x.ProtocolType).HasColumnName("PROTOCOL_TYPE");
                b.Property(x => x.RequireClientSecret).HasColumnName("REQUIRE_CLIENT_SECRET");
                b.Property(x => x.RequireConsent).HasColumnName("REQUIRE_CONSENT");
                b.Property(x => x.AllowRememberConsent).HasColumnName("ALLOW_REMEMBER_CONSENT");
                b.Property(x => x.AlwaysIncludeUserClaimsInIdToken).HasColumnName("ALWAYS_INCLUDE_USER_CLAIMS_INID_TOKEN");
                b.Property(x => x.RequirePkce).HasColumnName("REQUIRE_PKCE");
                b.Property(x => x.AllowPlainTextPkce).HasColumnName("ALLOW_PLAIN_TEXT_PKCE");
                b.Property(x => x.RequireRequestObject).HasColumnName("REQUIRE_REQUEST_OBJECT");
                b.Property(x => x.AllowAccessTokensViaBrowser).HasColumnName("ALLOW_ACCESS_TOKENS_VIA_BROWSER");
                b.Property(x => x.FrontChannelLogoutUri).HasColumnName("FRONT_CHANNEL_LOGOUT_URI");
                b.Property(x => x.FrontChannelLogoutSessionRequired).HasColumnName("FRONT_CHANNEL_LOGOUT_SESSION_REQUIRED");
                b.Property(x => x.BackChannelLogoutUri).HasColumnName("BACK_CHANNEL_LOGOUT_URI");
                b.Property(x => x.BackChannelLogoutSessionRequired).HasColumnName("BACK_CHANNEL_LOGOUT_SESSION_REQUIRED");
                b.Property(x => x.AllowOfflineAccess).HasColumnName("ALLOW_OFFLINE_ACCESS");
                b.Property(x => x.IdentityTokenLifetime).HasColumnName("IDENTITY_TOKEN_LIFETIME");
                b.Property(x => x.AllowedIdentityTokenSigningAlgorithms).HasColumnName("ALLOWED_IDENTITY_TOKEN_SIGNING_ALGORITHMS");
                b.Property(x => x.AccessTokenLifetime).HasColumnName("ACCESS_TOKEN_LIFETIME");
                b.Property(x => x.AuthorizationCodeLifetime).HasColumnName("AUTHORIZATION_CODE_LIFETIME");
                b.Property(x => x.ConsentLifetime).HasColumnName("CONSENT_LIFETIME");
                b.Property(x => x.AbsoluteRefreshTokenLifetime).HasColumnName("ABSOLUTE_REFRESH_TOKEN_LIFETIME");
                b.Property(x => x.SlidingRefreshTokenLifetime).HasColumnName("SLIDING_REFRESH_TOKEN_LIFETIME");
                b.Property(x => x.RefreshTokenUsage).HasColumnName("REFRESH_TOKEN_USAGE");
                b.Property(x => x.UpdateAccessTokenClaimsOnRefresh).HasColumnName("UPDATE_ACCESS_TOKEN_CLAIMS_ONREFRESH");
                b.Property(x => x.RefreshTokenExpiration).HasColumnName("REFRESH_TOKEN_EXPIRATION");
                b.Property(x => x.AccessTokenType).HasColumnName("ACCESS_TOKEN_TYPE");
                b.Property(x => x.EnableLocalLogin).HasColumnName("ENABLE_LOCAL_LOGIN");
                b.Property(x => x.IncludeJwtId).HasColumnName("INCLUDE_JWT_ID");
                b.Property(x => x.AlwaysSendClientClaims).HasColumnName("ALWAYS_SEND_CLIENT_CLAIMS");
                b.Property(x => x.ClientClaimsPrefix).HasColumnName("CLIENT_CLAIMS_PREFIX");
                b.Property(x => x.PairWiseSubjectSalt).HasColumnName("PAIR_WISE_SUBJECT_SALT");
                b.Property(x => x.UserSsoLifetime).HasColumnName("USER_SSO_LIFETIME");
                b.Property(x => x.UserCodeType).HasColumnName("USER_CODE_TYPE");
                b.Property(x => x.DeviceCodeLifetime).HasColumnName("DEVICE_CODE_LIFETIME");

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

            builder.Entity<ClientGrantType>(b =>
            {
                b.ToTable(options.TablePrefix + "CLIENT_GRANT_TYPE", options.Schema);
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.GrantType).HasColumnName("GRANT_TYPE"); ;

            });

            builder.Entity<ClientRedirectUri>(b =>
            {
                b.ToTable(options.TablePrefix + "CLIENT_REDIRECT_URI", options.Schema);
                b.Property(x => x.RedirectUri).HasColumnName("REDIRECT_URI");
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");

            });

            builder.Entity<ClientPostLogoutRedirectUri>(b =>
            {
                b.ToTable(options.TablePrefix + "CLIENT_POST_LOGOUT_REDIRECT_URI", options.Schema);
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.PostLogoutRedirectUri).HasColumnName("POST_LOGOUT_REDIRECT_URI");
            });

            builder.Entity<ClientScope>(b =>
            {
                b.ToTable(options.TablePrefix + "CLIENT_SCOPE", options.Schema);
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.Scope).HasColumnName("SCOPE");
            });

            builder.Entity<ClientSecret>(b =>
            {
                b.ToTable(options.TablePrefix + "CLIENT_SECRET", options.Schema);
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.Type).HasColumnName("TYPE");
                b.Property(x => x.Value).HasMaxLength(300).HasColumnName("VALUE");
                b.Property(x => x.Description).HasColumnName("DESCRIPTION");
                b.Property(x => x.Expiration).HasColumnName("EXPIRATION");
            });

            builder.Entity<ClientClaim>(b =>
            {
                b.ToTable(options.TablePrefix + "CLIENT_CLAIM", options.Schema);
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.Type).HasColumnName("TYPE");
                b.Property(x => x.Value).HasColumnName("VALUE");
            });

            builder.Entity<ClientIdPRestriction>(b =>
            {
                b.ToTable(options.TablePrefix + "CLIENTID_PRESTRICTION", options.Schema);
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.Provider).HasColumnName("PROVIDER");
            });

            builder.Entity<ClientCorsOrigin>(b =>
            {
                b.ToTable(options.TablePrefix + "CLIENT_CORS_ORIGIN", options.Schema);
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.Origin).HasColumnName("ORIGIN");
            });

            builder.Entity<ClientProperty>(b =>
            {
                b.ToTable(options.TablePrefix + "CLIENT_PROPERTY", options.Schema);
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.Key).HasColumnName("KEY");
                b.Property(x => x.Value).HasColumnName("VALUE");
            });

            #endregion

            #region IdentityResource

            builder.Entity<IdentityResource>(b =>
            {
                b.ToTable(options.TablePrefix + "IDENTITY_RESOURCE", options.Schema);

                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.Name).HasColumnName("NAME");
                b.Property(x => x.DisplayName).HasColumnName("DISPLAY_NAME");
                b.Property(x => x.Description).HasColumnName("DESCRIPTION");
                b.Property(x => x.Enabled).HasColumnName("ENABLED");
                b.Property(x => x.Required).HasColumnName("REQUIRED");
                b.Property(x => x.Emphasize).HasColumnName("EMPHASIZE");
                b.Property(x => x.ShowInDiscoveryDocument).HasColumnName("SHOWIN_DISCOVERY_DOCUMENT");

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

            builder.Entity<IdentityResourceClaim>(b =>
            {
                b.ToTable(options.TablePrefix + "IDENTITY_RESOURCE_CLAIM", options.Schema);
                b.Property(x => x.Type).HasColumnName("TYPE");
                b.Property(x => x.IdentityResourceId).HasColumnName("IDENTITY_RESOURCE_ID");
            });

            builder.Entity<IdentityResourceProperty>(b =>
            {
                b.ToTable(options.TablePrefix + "IDENTITY_RESOURCE_PROPERTY", options.Schema);
                b.Property(x => x.IdentityResourceId).HasColumnName("IDENTITY_RESOURCE_ID");
                b.Property(x => x.Key).HasColumnName("KEY");
                b.Property(x => x.Value).HasColumnName("VALUE");
            });

            #endregion

            #region ApiResource

            builder.Entity<ApiResource>(b =>
            {
                b.ToTable(options.TablePrefix + "API_RESOURCES", options.Schema);
                b.Property(x => x.Name).HasColumnName("NAME");
                b.Property(x => x.DisplayName).HasColumnName("DISPLAY_NAME");
                b.Property(x => x.Description).HasColumnName("DESCRIPTION");
                b.Property(x => x.Enabled).HasColumnName("ENABLED");
                b.Property(x => x.AllowedAccessTokenSigningAlgorithms).HasColumnName("ALLOWED_ACCESS_TOKEN_SIGNING_ALGORITHMS");
                b.Property(x => x.ShowInDiscoveryDocument).HasColumnName("SHOWIN_DISCOVERY_DOCUMENT");

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

            builder.Entity<ApiResourceSecret>(b =>
            {
                b.ToTable(options.TablePrefix + "API_RESOURCE_SECRET", options.Schema);
                b.Property(x => x.Type).HasColumnName("TYPE");
                b.Property(x => x.Value).HasMaxLength(300).HasColumnName("VALUE");
                b.Property(x => x.ApiResourceId).HasColumnName("API_RESOURCE_ID");
                b.Property(x => x.Description).HasColumnName("DESCRIPTION");
                b.Property(x => x.Expiration).HasColumnName("EXPIRATION");
            });

            builder.Entity<ApiResourceClaim>(b =>
            {
                b.ToTable(options.TablePrefix + "API_RESOURCE_CLAIM", options.Schema);
                b.Property(x => x.Type).HasColumnName("TYPE");
                b.Property(x => x.ApiResourceId).HasColumnName("API_RESOURCE_ID");
            });

            builder.Entity<ApiResourceScope>(b =>
            {
                b.ToTable(options.TablePrefix + "API_RESOURCE_SCOPE", options.Schema);
                b.Property(x => x.ApiResourceId).HasColumnName("API_RESOURCE_ID");
                b.Property(x => x.Scope).HasColumnName("SCOPE");
            });

            builder.Entity<ApiResourceProperty>(b =>
            {
                b.ToTable(options.TablePrefix + "API_RESOURCE_PROPERTY", options.Schema);
                b.Property(x => x.ApiResourceId).HasColumnName("API_RESOURCE_ID");
                b.Property(x => x.Key).HasColumnName("KEY");
                b.Property(x => x.Value).HasColumnName("VALUE");
            });

            #endregion

            #region ApiScope

            builder.Entity<ApiScope>(b =>
            {
                b.ToTable(options.TablePrefix + "API_SCOPE", options.Schema);

                b.Property(x => x.Enabled).HasColumnName("ENABLED");
                b.Property(x => x.Name).HasColumnName("NAME");
                b.Property(x => x.DisplayName).HasColumnName("DISPLAY_NAME");
                b.Property(x => x.Description).HasColumnName("DESCRIPTION");
                b.Property(x => x.Required).HasColumnName("REQUIRED");
                b.Property(x => x.Emphasize).HasColumnName("EMPHASIZE");
                b.Property(x => x.ShowInDiscoveryDocument).HasColumnName("SHOWIN_DISCOVERY_DOCUMENT");

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

            builder.Entity<ApiScopeClaim>(b =>
            {
                b.ToTable(options.TablePrefix + "API_SCOPE_CLAIM", options.Schema);
                b.Property(x => x.ApiScopeId).HasColumnName("API_SCOPE_ID");
                b.Property(x => x.Type).HasColumnName("TYPE");
            });

            builder.Entity<ApiScopeProperty>(b =>
            {
                b.ToTable(options.TablePrefix + "API_SCOPE_PROPERTY", options.Schema);
                b.Property(x => x.ApiScopeId).HasColumnName("API_SCOPE_ID");
                b.Property(x => x.Key).HasColumnName("KEY");
                b.Property(x => x.Value).HasColumnName("VALUE");
            });

            #endregion

            #region PersistedGrant

            builder.Entity<PersistedGrant>(b =>
            {
                b.ToTable(options.TablePrefix + "PERSISTED_GRANT", options.Schema);
                b.Property(x => x.Key).HasColumnName("KEY");
                b.Property(x => x.Type).HasColumnName("TYPE");
                b.Property(x => x.SubjectId).HasColumnName("SUBJECT_ID");
                b.Property(x => x.SessionId).HasColumnName("SESSION_ID");
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.Description).HasColumnName("DESCRIPTION");
                b.Property(x => x.CreationTime).HasColumnName("CREATION_TIME").HasColumnType("DATE");

                b.Property(x => x.Expiration).HasColumnName("EXPIRATION");
                b.Property(x => x.ConsumedTime).HasColumnName("CONSUMED_TIME").HasColumnType("DATE"); ;
                b.Property(x => x.Id).HasColumnName("ID");
                b.Property(x => x.ExtraProperties).HasColumnName("EXTRA_PROPERTIES");
                b.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
            });

            #endregion

            #region DeviceFlowCodes

            builder.Entity<DeviceFlowCodes>(b =>
            {
                b.ToTable(options.TablePrefix + "DEVICE_FLOW_CODE", options.Schema);
                b.Property(x => x.DeviceCode).HasColumnName("DEVICE_CODE");
                b.Property(x => x.UserCode).HasColumnName("USER_CODE");
                b.Property(x => x.SubjectId).HasColumnName("SUBJECT_ID");
                b.Property(x => x.SessionId).HasColumnName("SESSION_ID");
                b.Property(x => x.ClientId).HasColumnName("CLIENT_ID");
                b.Property(x => x.Description).HasColumnName("DESCRIPTION");
                b.Property(x => x.Expiration).HasColumnName("EXPIRATION");
                b.Property(x => x.Data).HasColumnName("DATA");

                b.Property(x => x.CreationTime).HasColumnName("CREATION_TIME").HasColumnType("DATE");
                b.Property(x => x.CreatorId).HasColumnName("CREATOR_ID");
                b.Property(x => x.ExtraProperties).HasColumnName("EXTRA_PROPERTIES");
                b.Property(x => x.ConcurrencyStamp).HasColumnName("CONCURRENCY_STAMP");
            });

            #endregion
        }

    }
}
