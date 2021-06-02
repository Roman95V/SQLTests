using NUnit.Framework;
using SQL.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SQL.Tests.Steps
{
    [Binding]
    public class DataBaseTestsSteps
    {
        private readonly SqlHelper _sqlHelper = new SqlHelper("Shop");

        [Given(@"Establish a database connection")]
        public void GivenEstablishADatabaseConnection()
        {
            _sqlHelper.OpenConnection();
        }

        [Given(@"Created row in table with data")]
        public void GivenCreatedRowInTableWithData(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            _sqlHelper.Insert("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });
        }

        [When(@"I insert row in table with data")]
        public void WhenIInsertRowInTableWithData(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            _sqlHelper.Insert("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });
        }


        [When(@"I delete  product in the products table")]
        public void WhenIDeleteProductInTheProductsTable(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            _sqlHelper.Delete("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });
        }

       
        [When(@"I update  product in the products table")]
        public void WhenIUpdateProductInTheProductsTsble(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            _sqlHelper.Edit("Products",
                new Dictionary<string, string> { { "Id", $"{ productModels[0].Id }" }, { "Name", $"'{ productModels[0].Name }'" }, { "Count", $"{ productModels[0].Count }" } },
                new Dictionary<string, string> { { "Id", $"{ productModels[1].Id }" }, { "Name", $"'{ productModels[1].Name }'" }, { "Count", $"{ productModels[1].Count }" } });
        }  

        [Then(@"Succesfully row inserted with data")]
        public void ThenSuccesfullyRowInsertedWithData(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            var res =_sqlHelper.IsRowExistedInTable("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });

            Assert.IsTrue(res);

        }


        [Then(@"Succesfully updated product in the products table")]
        public void ThenSuccesfullyUpdatedProductInTheProductsTable(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            var res =_sqlHelper.IsRowExistedInTable("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });
            Assert.IsTrue(res);
        }

        [Then(@"Succesfully deleted product in the products table")]
        public void ThenSuccesfullyDeletedProductInTheProductsTable(Table table)
        {
            var productModels = table.CreateSet<ProductModel>().ToList();

            var res = _sqlHelper.IsRowExistedInTable("Products",
                new Dictionary<string, string> {
                    { "Id", $"{ productModels[0].Id }" },
                    { "Name", $"'{ productModels[0].Name }'" },
                    { "Count", $"{ productModels[0].Count }" }
                });
            Assert.IsFalse(res);
        }

        public class ProductModel
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Count { get; set; }
        }
    }
}
