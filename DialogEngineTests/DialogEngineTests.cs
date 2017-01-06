using DialogEngine.Engine;
using DialogEngine.EngineModel;
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
    public class DialogEngineTests
    {
        private ConversationDataBuilder builder = new ConversationDataBuilder();
        private StatementLinkBuilder linkBuilder = new StatementLinkBuilder();
        private StatementBuilder statementBuilder = new StatementBuilder();


        [TestMethod]
        public void AdvanceToNextLinkTest()
        {
            var chosenStatement = statementBuilder.GetNewStatement(35);
            var currentLink = linkBuilder.GetNewStatementLink(99);
            var nextLink = linkBuilder.GetNewStatementLink(87);
            var action = new ConversationAction();
            var conversationData = new ConversationData();

            currentLink.Links.Add(new Link() { StatementID = chosenStatement.ID, NextLinkID = nextLink.ID });
            action.ChosenStatement = chosenStatement;
            action.CurrentStatementLink = currentLink;
            conversationData.StatementLinks.AddRange(new List<StatementLink> { currentLink, nextLink });

            var director = new ConversationDirector(conversationData);
            var result = director.Advance(action);

            Assert.AreEqual(nextLink.ID, result.CurrentStatementLink.ID);
        }
    }
}
