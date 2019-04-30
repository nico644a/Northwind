using System;
using System.Data;
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

        [TestMethod]
        public void CanExecuteSql()
        {
            // Arrange:
            string sql = "SELECT * FROM Employees";
            Repository repository = new Repository();
            DataSet result;
            int rowCount;

            // Act:
            result = repository.Execute(sql);

            // Assert:
            rowCount = result.Tables[0].Rows.Count;
            Assert.IsTrue(rowCount > 0);
        }
    }
}
