using DialogEngine.EngineModel;
using DialogEngine.Model;
using System.Collections.Generic;

namespace DialogEngineTests.Data
{
    public class ConversationDataBuilder
    {
        private StatementLinkBuilder linkBuilder = new StatementLinkBuilder();
        private StatementBuilder statementBuilder = new StatementBuilder();


        public ConversationData GetConversationData()
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

            return conversationData;
        }
    }
}
