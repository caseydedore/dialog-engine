using DialogEngine.Data;
using DialogEngine.Model;
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
        private StatementBuilder statementBuilder = new StatementBuilder();
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
            }
        }

        [TestMethod]
        public void GetStatementsInLinkTest()
        {
            var statements = statementBuilder.GetNewStatements(100);
            var statementLink = new StatementLink();

            var statementsInLink = new List<Statement>();

            var link = new Link();

            for (var i = 0; i < 100; i += 10)
            {
                statementsInLink.Add(statements[i]);

                link = new Link()
                {
                    StatementID = statements[i].ID
                };

                statementLink.Links.Add(link);
            }

            var retrievedStatements = access.GetStatements(statementLink, statements);

            Assert.AreEqual(statementsInLink.Count, retrievedStatements.Count);

            for (var i = 0; i < statementsInLink.Count; i++)
            {
                Assert.AreEqual(statementsInLink[i].ID, retrievedStatements[i].ID);
            }
        }

        [TestMethod]
        public void GetStatementLinkByStatementIDTest()
        {
            //var retrievedLink = access.GetStatementLinkByStatementID();
        }
    }
}
