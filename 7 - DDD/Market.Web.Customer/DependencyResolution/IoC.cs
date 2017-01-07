using Market.Web.CustomerFacing.DependencyResolution;
using StructureMap;

namespace Market.Web.Customer.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}
