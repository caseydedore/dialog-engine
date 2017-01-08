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
            //Assert.AreEqual(statement.AttitudeID, retrievedStatement.AttitudeID);
        }
    }
}
