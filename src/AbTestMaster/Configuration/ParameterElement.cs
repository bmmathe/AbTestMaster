using System.Configuration;

namespace AbTestMaster.Configuration
{
    public class ParameterElement : ConfigurationElement
    {
        public ParameterElement()
        {
        }
        public ParameterElement(string name, string value)
        {
            this.Value = value;
            this.Name = name;
        }

        [ConfigurationProperty("name", IsRequired = true, IsKey = true, DefaultValue = "")]
        public string Name
        {
            get { return (string)this["name"]; }
            set { this["name"] = value; }
        }

        [ConfigurationProperty("value", IsRequired = true)]
        public string Value
        {
            get { return (string)this["value"]; }
            set { this["value"] = value; }
        }
    }
}