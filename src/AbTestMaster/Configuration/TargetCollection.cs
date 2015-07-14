using System;
using System.Configuration;

namespace AbTestMaster.Configuration
{
    public class TargetCollection : ConfigurationElementCollection
    {
        [ConfigurationProperty("throwexceptions", DefaultValue = false)]
        public bool ThrowExceptions
        {
            get { return (bool)base["throwexceptions"]; }
        }
        public TargetCollection()
        {
            var details = (TargetElement)CreateNewElement();
            if (details.Name != "")
            {
                Add(details);
            }
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }
        protected override ConfigurationElement CreateNewElement()
        {
            return new TargetElement();
        }
        protected override Object GetElementKey(ConfigurationElement element)
        {
            return ((TargetElement)element).Name;
        }
        public TargetElement this[int index]
        {
            get
            {
                return (TargetElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }
        new public TargetElement this[string name]
        {
            get
            {
                return (TargetElement)BaseGet(name);
            }
        }
        public int IndexOf(TargetElement details)
        {
            return BaseIndexOf(details);
        }
        public void Add(TargetElement details)
        {
            BaseAdd(details);
        }
        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);
        }
        public void Remove(TargetElement details)
        {
            if (BaseIndexOf(details) >= 0)
                BaseRemove(details.Name);
        }
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
        public void Remove(string name)
        {
            BaseRemove(name);
        }
        public void Clear()
        {
            BaseClear();
        }
        protected override string ElementName
        {
            get { return "target"; }
        }
    }
}