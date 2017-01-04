using DialogEngine.Data;
using DialogEngineTests.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DialogEngineTests
{
    [TestClass]
    public class StatementLinkAccessTests
    {
        private StatementLinkBuilder builder = new StatementLinkBuilder();
        private StatementLinkAccess access = new StatementLinkAccess();


        [TestMethod]
        public void GetStatementLinkTest()
        {
            var links = builder.GetNewStatementLinks();
            var link = links[7];

            var retrievedLink = access.GetStatementLink(link.ID, links);

            Assert.AreEqual(link.ID, retrievedLink.ID);
            Assert.AreEqual(link.Links, retrievedLink.Links);

            for(var i = 0; i < link.Links.Count; i++)
            {
                Assert.AreEqual(link.Links[i].StatementID, retrievedLink.Links[i].StatementID);
                Assert.AreEqual(link.Links[i].NextLinkID, retrievedLink.Links[i].NextLinkID);
                Assert.AreEqual(link.Links[i].ActorID, retrievedLink.Links[i].ActorID);
                Assert.AreEqual(link.Links[i].Condition, retrievedLink.Links[i].Condition);
            }
        }

        [TestMethod]
        public void GetStatementLinkByStatementIDTest()
        {
            //var retrievedLink = access.GetStatementLinkByStatementID();
        }
    }
}
