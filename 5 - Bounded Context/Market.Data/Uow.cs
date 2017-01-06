namespace Market.Data
{
    public class Uow
    {
        private readonly MarketContext _context;
        public Uow()
        {
            _context = new MarketContext();
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}