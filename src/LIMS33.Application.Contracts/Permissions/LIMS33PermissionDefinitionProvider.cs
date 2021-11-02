using LIMS33.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace LIMS33.Permissions
{
    public class LIMS33PermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(LIMS33Permissions.GroupName);
            //Define your own permissions here. Example:
            //myGroup.AddPermission(LIMS33Permissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<LIMS33Resource>(name);
        }
    }
}
