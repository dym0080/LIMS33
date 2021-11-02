using Volo.Abp.Settings;

namespace LIMS33.Settings
{
    public class LIMS33SettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(LIMS33Settings.MySetting1));
        }
    }
}
