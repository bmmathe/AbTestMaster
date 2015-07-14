using System.Configuration;

namespace AbTestMaster.Configuration
{
    public class SplitViewElement : ConfigurationElement
    {
        [ConfigurationProperty("overrideSettingsFromDatabase", DefaultValue = false)]
        public bool OverrideSettingsFromDatabase
        {
            get { return (bool)base["overrideSettingsFromDatabase"]; }
        }

        [ConfigurationProperty("connectionStringName", IsRequired = true)]
        public string ConnectionStringName
        {
            get { return (string)base["connectionStringName"]; }
        }
    }
}
