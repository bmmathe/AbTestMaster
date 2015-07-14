using System.Configuration;

namespace AbTestMaster.Configuration
{
    public class TargetElement : ConfigurationElement
    {
        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return (string)this["type"]; }
            set { this["type"] = value; }
        }

        [ConfigurationProperty("data", IsRequired = true)]
        public string Data
        {
            get { return (string)this["data"]; }
            set { this["data"] = value; }
        }

        [ConfigurationProperty("connectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)this["connectionStringName"]; }
            set { this["connectionStringName"] = value; }
        }

        [ConfigurationProperty("commandText")]
        public string CommandText
        {
            get { return (string)this["commandText"]; }
            set { this["commandText"] = value; }
        }

        [ConfigurationProperty("path")]
        public string Path
        {
            get { return (string)this["path"]; }
            set { this["path"] = value; }
        }

        [ConfigurationProperty("", IsDefaultCollection = true)]
        public ParameterCollection Parameters
        {
            get { return (ParameterCollection)base[""]; }

        }
    }
}