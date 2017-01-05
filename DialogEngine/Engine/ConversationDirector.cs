using DialogEngine.Data;
using DialogEngine.EngineModel;

namespace DialogEngine.Engine
{
    public class ConversationDirector
    {
        private StatementLinkAccess statementLinkAccess = new StatementLinkAccess();
        private StatementAccess statementAccess = new StatementAccess();
        private ActorAccess actorAccess = new ActorAccess();

        private ConversationData ConversationData { get; }


        public ConversationDirector (ConversationData package)
        {
            ConversationData = package;
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
            //They're intended to cull the possible FUTURE options that are given in response to the CURRENT chosen statement.
            //The chosen statement needs known before condition checking, or all future link options would be checked early.
            //Is this feasible?

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