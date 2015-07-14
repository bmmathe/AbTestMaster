using System.Configuration;

namespace AbTestMaster.Configuration
{
    public class ParameterCollection : ConfigurationElementCollection
    {
        public new ParameterElement this[string name]
        {
            get
            {
                if (IndexOf(name) < 0) return null;
                return (ParameterElement)BaseGet(name);
            }
        }
        public ParameterElement this[int index]
        {
            get { return (ParameterElement)BaseGet(index); }
        }
        public int IndexOf(string name)
        {
            name = name.ToLower();
            for (int idx = 0; idx < base.Count; idx++)
            {
                if (this[idx].Name.ToLower() == name)
                    return idx;
            }
            return -1;
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new ParameterElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ParameterElement)element).Name;
        }
        protected override string ElementName
        {
            get { return "parameter"; }
        }
    }
}