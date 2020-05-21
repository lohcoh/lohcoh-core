using LowKode.Core.Common;
using LowKode.Core.Components;
using static LowKode.Core.Context.IContext.Properties;

namespace LowKode.Core.Context
{
    /// <summary>
    /// The root node of the LowKode context system.
    /// </summary>
    public interface IContext : IDependencyObject
    {
        public static class Properties 
        {
            public static readonly IDependencyProperty<ISiteSpecification> ComponentSiteSpecificationProperty = 
                new DependencyProperty<ISiteSpecification>();
        }

        ISiteSpecification ComponentSiteSpecification
        {
            get { return this.GetValue(ComponentSiteSpecificationProperty); }
            set { this.SetValue(ComponentSiteSpecificationProperty, value); }
        }

    }
}
