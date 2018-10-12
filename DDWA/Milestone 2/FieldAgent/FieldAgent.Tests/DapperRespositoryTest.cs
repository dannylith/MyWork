using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO_Repository.Dapper;
using NUnit.Framework;

namespace FieldAgent.Tests
{
    [TestFixture]
    public class DapperRespositoryTest
    {
        [Test]
        public void GetAllTest()
        {
            var repo = new DapperAgentRepository();
            var result = repo.All();

            Assert.IsTrue(result != null && result.Any());
        }
    }
}
