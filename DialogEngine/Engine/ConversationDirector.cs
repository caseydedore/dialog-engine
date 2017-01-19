using DialogEngine.Data;
using DialogEngine.EngineModel;
using DialogEngine.Model;
using System.Collections.Generic;

namespace DialogEngine.Engine
{
    public class ConversationDirector
    {
        private StatementLinkAccess statementLinkAccess = new StatementLinkAccess();
        private StatementAccess statementAccess = new StatementAccess();
        private ActorAccess actorAccess = new ActorAccess();

        private ConditionManager conditionManager = null;

        private Conversation ConversationData { get; }


        public ConversationDirector(Conversation package)
        {
            ConversationData = package;
            conditionManager = new ConditionManager(package.Conditions);
        }

        public ConversationResult Start()
        {
            return GetStartingConversationResult(ConversationData.StartingStatementLinkID);
        }

        public ConversationResult Advance(ConversationAction action)
        {
            return GetConversationResultByAction(action);
        }

        private ConversationResult GetConversationResultByAction(ConversationAction action)
        {
            var result = new ConversationResult(ConversationStatus.Active);
            var actor = new Actor();
            var nextLink = new StatementLink();
            var statements = new List<Statement>();

            try
            {
                var nextLinkID =
                    statementLinkAccess.GetNextLinkIdForStatement(action.ChosenStatement.ID, action.CurrentStatementLink);

                nextLink = statementLinkAccess.GetStatementLink(nextLinkID, ConversationData.StatementLinks);

                actor = actorAccess.GetActor(nextLink.ActorID, ConversationData.Actors);

                var modifiers =
                    statementLinkAccess.GetModifiersForStatement(action.ChosenStatement.ID, action.CurrentStatementLink);

                conditionManager.ModifyConditions(modifiers);

                var requirements =
                    statementLinkAccess.GetRequirements(nextLink);

                var failedRequirements =
                    conditionManager.GetFailedRequirements(requirements);

                var statementIds =
                    statementLinkAccess.GetStatementIDsExcludingRequirements(nextLink, failedRequirements);

                statements = statementAccess.GetStatements(statementIds, ConversationData.Statements);
            }
            catch
            {
                result = new ConversationResult(ConversationStatus.Terminated);
            }
            
            result.CurrentStatementLink = nextLink;
            result.Statements = statements;
            result.CurrentActor = actor;

            return result;
        }

        private ConversationResult GetStartingConversationResult(uint statementLinkId)
        {
            var result = new ConversationResult(ConversationStatus.Active);

            var actor = new Actor();
            var link = new StatementLink();
            var statements = new List<Statement>();
            try
            {
                link = statementLinkAccess.GetStatementLink(statementLinkId, ConversationData.StatementLinks);

                statements = statementLinkAccess.GetStatements(link, ConversationData.Statements);

                actor = actorAccess.GetActor(link.ActorID, ConversationData.Actors);
            }
            catch
            {
                result = new ConversationResult(ConversationStatus.Terminated);
            }

            result.CurrentActor = actor;
            result.CurrentStatementLink = link;
            result.Statements = statements;

            return result;
        }
    }
}