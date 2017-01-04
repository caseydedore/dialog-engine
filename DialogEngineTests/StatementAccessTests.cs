using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DialogEngineTests.Data;
using DialogEngine.Data;
using DialogEngine.Model;
using System.Collections.Generic;

namespace DialogEngineTests
{
    [TestClass]
    public class StatementAccessTests
    {
        private StatementBuilder builder = new StatementBuilder();
        private StatementAccess access = new StatementAccess();


        [TestMethod]
        public void GetStatementTest()
        {
            var statements = builder.GetNewStatements();
            var statement = statements[4];
            var id = statement.ID;

            var retrievedStatement = access.GetStatement(id, statements);

            Assert.AreEqual(statement.ID, retrievedStatement.ID);
            Assert.AreEqual(statement.Dialog, retrievedStatement.Dialog);
            Assert.AreEqual(statement.AttitudeID, retrievedStatement.AttitudeID);
        }

        [TestMethod]
        public void GetStatementsInLinkTest()
        {
            var statements = builder.GetNewStatements(100);
            var statementLink = new StatementLink();

            var statementsInLink = new List<Statement>();

            var link = new Link();

            for(var i = 0; i < 100; i += 10)
            {
                statementsInLink.Add(statements[i]);

                link = new Link()
                {
                    StatementID = statements[i].ID
                };

                statementLink.Links.Add(link);
            }

            var retrievedStatements = access.GetStatementsInStatementLink(statementLink, statements);

            Assert.AreEqual(statementsInLink.Count, retrievedStatements.Count);
    
            for(var i = 0; i < statementsInLink.Count; i++)
            {
                Assert.AreEqual(statementsInLink[i].ID, retrievedStatements[i].ID);
            }
        }
    }
}
