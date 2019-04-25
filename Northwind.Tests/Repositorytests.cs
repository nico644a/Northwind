using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Northwind.DataAccess;

namespace Northwind.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void RepositoryInitializationSucceeds()
        {
            // Arrange:
            Repository repository;
            
            // Act:
            repository = new Repository();
        }
    }
}
