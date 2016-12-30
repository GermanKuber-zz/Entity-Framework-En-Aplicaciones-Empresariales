using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Market.Data;
using Market.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Market.Test.Data
{
    [TestClass]
    public class GenericRepositoryIntegrationTests
    {
        private StringBuilder _logBuilder = new StringBuilder();
        private string _log;
        private MarketContext _context;
        private GenericRepository<Customer> _customerRepository;

        public GenericRepositoryIntegrationTests()
        {
            Database.SetInitializer(new NullDatabaseInitializer<MarketContext>());
            _context = new MarketContext();
            _customerRepository = new GenericRepository<Customer>(_context);
            SetupLogging();
        }





        [TestMethod]
        public void NoTrackingQueriesDoNotCacheObjects()
        {
            var results = _customerRepository.All();
            Assert.AreEqual(0, _context.ChangeTracker.Entries().Count());
        }





        [TestMethod]
        public void ComposedOnAllListExecutedInMemory()
        {
            _customerRepository.All().Where(c => c.FirstName == "Mariano").ToList();
            WriteLog();
            Assert.IsFalse(_log.Contains("Mariano"));
        }

        private void WriteLog()
        {
            Debug.WriteLine(_log);
        }

        private void SetupLogging()
        {
            _context.Database.Log = BuildLogString;
        }

        private void BuildLogString(string message)
        {
            _logBuilder.Append(message);
            _log = _logBuilder.ToString();
        }
    }
}