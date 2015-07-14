using System.Configuration;

namespace AbTestMaster.Configuration
{
    public class AbTestMasterSection : ConfigurationSection
    {
        [ConfigurationProperty("targets", IsDefaultCollection = false)]
        public TargetCollection Targets
        {
            get { return (TargetCollection)base["targets"]; }
        }

        [ConfigurationProperty("splitViews", IsDefaultCollection = false)]
        public SplitViewElement SplitViews
        {
            get { return (SplitViewElement) base["splitViews"]; }
        }
    }
}
