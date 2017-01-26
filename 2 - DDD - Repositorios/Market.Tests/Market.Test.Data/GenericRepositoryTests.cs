using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Market.Data;
using Market.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Market.Test.Data
{
    //TODO 13 -  Testeo Generic Repository
    [TestClass]
    public class GenericRepositoryIntegrationTests
    {
        private readonly StringBuilder _logBuilder = new StringBuilder();
        private string _log;
        private readonly MarketContext _context;
        private readonly GenericRepository<Customer> _customerRepository;

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

        //TODO 10 - Sistema de Log para pruebas de integración
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




        [TestMethod]
        public void CanFindByCustomerByKeyWithDynamicLambda()
        {
            var results = _customerRepository.FindByKey(1);
            WriteLog();
            Assert.IsTrue(_log.Contains("FROM [dbo].[Customers"));
        }

        [TestMethod]
        public void CanFindByProductByKeyWithDynamicLambda()
        {
            var results = new GenericRepository<Product>(_context).FindByKey(1);
            WriteLog();
            Assert.IsTrue(_log.Contains("FROM [dbo].[Products"));
        }




        [TestMethod]
        public void CanQueryWithSinglePredicate()
        {
            var results = _customerRepository.FindBy(c => c.LastName.StartsWith("L"));
            WriteLog();
            Assert.IsTrue(_log.Contains("'L%'"));
        }

        [TestMethod]
        public void CanQueryWithDualPredicate()
        {
            var date = new DateTime(2001, 1, 1);
            var results = _customerRepository
              .FindBy(c => c.LastName.StartsWith("L") && c.DateOfBirth >= date);
            WriteLog();
            Assert.IsTrue(_log.Contains("'L%'") && _log.Contains("01/01/2001"));
        }

        [TestMethod]
        public void CanQueryWithComplexRelatedPredicate()
        {
            var date = new DateTime(2001, 1, 1);
            var results = _customerRepository
               .FindBy(c => c.LastName.StartsWith("L") && c.DateOfBirth >= date
                                                       && c.Orders.Any());
            WriteLog();
            Assert.IsTrue(_log.Contains("'L%'") && _log.Contains("01/01/2001") && _log.Contains("Orders"));
        }

        [TestMethod]
        public void GetAllIncludingComprehendsSingleNavigation()
        {
            var results = _customerRepository.GetAllIncluding(c => c.Orders);
            Assert.IsTrue(results.Any(c => c.Orders.Any()));
        }

        [TestMethod]
        public void GetAllIncludingComprehendsTwoChildNavigation()
        {
            var results = _customerRepository
              .GetAllIncluding(c => c.Orders, c => c.ContactDetail);

            Assert.IsTrue(results.Any(c => c.Orders.Any()));
        }

        [TestMethod]
        public void GetAllIncludingComprehendsTwoLevelNavigation()
        {
            var results = _customerRepository
              .GetAllIncluding(c => c.Orders, c => c.Orders.Select(o => o.LineItems));

            Assert.IsTrue(results.Any(c => c.Orders.Any()));
        }

        [TestMethod]
        public void CanIncludeNavigationProperties()
        {
            var results = _customerRepository.GetAllIncluding(c => c.Orders);

            Assert.IsTrue(results.Any(c => c.Orders.Any()));
        }


    }
}