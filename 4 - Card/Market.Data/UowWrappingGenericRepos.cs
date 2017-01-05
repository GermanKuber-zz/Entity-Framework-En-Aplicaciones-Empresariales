using Market.Domain;

namespace Market.Data
{
    public class UowWrappingGenericRepos
    {
        private GenericRepository<Customer> _custRepo;
        private GenericRepository<Order> _orderRepo;
        readonly MarketContext _context;
        public UowWrappingGenericRepos()
        {
            _context = new MarketContext();
        }
        public GenericRepository<Customer> CustomerRepository
        {
            get
            {

                if (_custRepo == null)
                {
                    _custRepo = new GenericRepository<Customer>(_context);
                }
                return _custRepo;
            }
        }

        public GenericRepository<Order> OrderRepository
        {
            get
            {

                if (this._orderRepo == null)
                {
                    this._orderRepo = new GenericRepository<Order>(_context);
                }
                return _orderRepo;
            }
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}