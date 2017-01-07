using DialogEngine.Data;
using DialogEngine.EngineModel;

namespace DialogEngine.Engine
{
    public class ConversationDirector
    {
        private StatementLinkAccess statementLinkAccess = new StatementLinkAccess();
        private StatementAccess statementAccess = new StatementAccess();
        private ActorAccess actorAccess = new ActorAccess();

        private ConditionManager conditionManager = null;

        private ConversationData ConversationData { get; }


        public ConversationDirector (ConversationData package)
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
                statementLinkAccess.GetStatementLinkByStatementID(action.CurrentStatementLink, action.ChosenStatement.ID);

            var nextLink =
                statementLinkAccess.GetStatementLink(nextLinkID, ConversationData.StatementLinks);

            var statements =
                statementAccess.GetStatementsInStatementLink(nextLink, ConversationData.Statements);

            //Condition checking needs to occur.
            //First, if there is a condition modifier attached to the chosen statment, apply that
            //Then check the next statementlink's conditions to cull any links whose conditions don't validate

            var actor =
                actorAccess.GetActor(nextLinkID, ConversationData.Actors);

            var result = new ConversationResult();
            result.CurrentStatementLink = nextLink;
            result.Statements = statements;
            result.CurrentActor = actor;

            return result;
        }
    }
}