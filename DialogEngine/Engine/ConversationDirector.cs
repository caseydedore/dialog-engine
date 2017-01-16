using DialogEngine.Data;
using DialogEngine.EngineModel;
using DialogEngine.Model;

namespace DialogEngine.Engine
{
    public class ConversationDirector
    {
        private StatementLinkAccess statementLinkAccess = new StatementLinkAccess();
        private StatementAccess statementAccess = new StatementAccess();
        private ActorAccess actorAccess = new ActorAccess();

        private ConditionManager conditionManager = null;

        private ConversationData ConversationData { get; }


        public ConversationDirector(ConversationData package)
        {
            ConversationData = package;
            conditionManager = new ConditionManager(package.Conditions);
        }

        public ConversationResult Advance(ConversationAction action)
        {
            return GetConversationResultByAction(action);
        }

        private ConversationResult GetConversationResultByAction(ConversationAction action)
        {
            var nextLinkID =
                statementLinkAccess.GetNextLinkIdForStatement(action.ChosenStatement.ID, action.CurrentStatementLink);

            var nextLink =
                statementLinkAccess.GetStatementLink(nextLinkID, ConversationData.StatementLinks);

            var actor =
                actorAccess.GetActor(nextLinkID, ConversationData.Actors);

            var modifiers =
                statementLinkAccess.GetModifiersForStatement(action.ChosenStatement.ID, action.CurrentStatementLink);

            conditionManager.ModifyConditions(modifiers);

            var requirements =
                statementLinkAccess.GetRequirements(nextLink);

            var failedRequirements =
                conditionManager.GetFailedRequirements(requirements);

            var statementIds =
                statementLinkAccess.GetStatementIdsWithoutRequirements(action.CurrentStatementLink, failedRequirements);

            var statements =
                statementAccess.GetStatements(statementIds, ConversationData.Statements);

            var result = new ConversationResult();
            result.CurrentStatementLink = nextLink;
            result.Statements = statements;
            result.CurrentActor = actor;

            return result;
        }
    }
}