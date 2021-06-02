
using System.Collections.Generic;
using NUnit.Framework;

namespace SQL.Tests
{
    public class Tests
    {
        private SqlHelper _sqlHelper;

        [SetUp]
        public void Setup()
        {
            _sqlHelper = new SqlHelper("Shop");
            _sqlHelper.OpenConnection();
        }

        [TearDown]
        public void TearDown()
        {
            _sqlHelper.ExecuteNonQuery("delete from [Shop].[dbo].[Products] where id = 23");
            _sqlHelper.CloseConnection();
        }
   
        [Test]
        public void Insert()
        {

           _sqlHelper.Insert("Products",
               new Dictionary<string, string> { { "Id", "1" }, { "Name", "'Test23'" }, { "Count", "234" } });
           var res = _sqlHelper.IsRowExistedInTable("Products",
               new Dictionary<string, string> { { "Id", "1" }, { "Name", "'Test23'" }, { "Count", "234" } });
          
           Assert.True(res);
        }

        [Test]
        public void Edit()
        {
            _sqlHelper.Insert("Products",
               new Dictionary<string, string> { { "Id", "2" }, { "Name", "'Test28'" }, { "Count", "228" } });

            _sqlHelper.Edit("Products",
                new Dictionary<string, string> { { "Id", "2" }, { "Name", "'Test28'" }, { "Count", "228" } },
                new Dictionary<string, string> { { "Id", "3" }, { "Name", "'Test24'" }, { "Count", "300" } });

            var res = _sqlHelper.IsRowExistedInTable("Products",
                new Dictionary<string, string> { { "Id", "3" }, { "Name", "'Test24'" }, { "Count", "300" } });

            Assert.IsTrue(res);
        }

        [Test]
        public void Delete()
        {
           // _sqlHelper.Insert("Products",
               // new Dictionary<string, string> { { "Id", "23" }, { "Name", "'Test23'" }, { "Count", "234" } });

            _sqlHelper.Delete("Products",
                new Dictionary<string, string> { { "Name", "'Test24'" }, { "Count", "300" } });

            var res = _sqlHelper.IsRowExistedInTable("Products",
                new Dictionary<string, string> { { "Id", "3" }, { "Name", "'Test24'" }, { "Count", "300" } });

            Assert.IsFalse(res);
        }
    }
}

   
    