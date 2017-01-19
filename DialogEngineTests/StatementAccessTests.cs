using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DialogEngineTests.Data;
using DialogEngine.Data;
using DialogEngine.Model;
using System.Collections.Generic;
using System.Linq;

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
        }

        [TestMethod]
        public void GetStatementsTest()
        {
            var statements = builder.GetNewStatements();
            var targetStatements = statements.GetRange(2, 3);
            targetStatements.Add(statements[8]);
            var targetIds = targetStatements.Select(t => t.ID).ToList();

            var retrievedStatements = access.GetStatements(targetIds, statements);

            Assert.AreEqual(targetStatements.Count, retrievedStatements.Count);

            for(var i = 0; i < targetStatements.Count; i++)
            {
                Assert.AreEqual(targetStatements[i].ID, retrievedStatements[i].ID);
                Assert.AreEqual(targetStatements[i].Dialog, retrievedStatements[i].Dialog);
            }
        }
    }
}
