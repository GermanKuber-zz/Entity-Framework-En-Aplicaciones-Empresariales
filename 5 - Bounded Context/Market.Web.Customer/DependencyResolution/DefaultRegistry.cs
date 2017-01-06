using Market.Data;
using StructureMap;
using StructureMap.Graph;
using System.Data.Entity;


namespace Market.Web.CustomerFacing.DependencyResolution
{
    // using DisconnectedGenericRepository;

    public class DefaultRegistry : Registry
    {
        #region Constructors and Destructors

        public DefaultRegistry()
        {
            Scan(
                scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });
            //remember that Transient is the default. Left it here as a reminder
            For<DbContext>().Use<MarketContext>().Transient();


            //Alternate
            //For(typeof(GenericRepository<>))
            //  .Use(typeof(GenericRepository<>))
            //  .Ctor<DbContext>().Is(new OrderSystemContext());
        }

        #endregion Constructors and Destructors
    }
}