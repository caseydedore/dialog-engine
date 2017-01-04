using DialogEngine.Data;
using DialogEngine.EngineModel;
using DialogEngine.Model;

namespace DialogEngine.Engine
{
    public class ConversationDirector
    {
        private StatementLinkAccess statementLinkAccess = new StatementLinkAccess();
        private StatementAccess statmentAccess = new StatementAccess();
        private ActorAccess actorAccess = new ActorAccess();

        private ConversationData ConversationPackage { get; set; }


        public void Start(ConversationData package)
        {
            ConversationPackage = package;
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
                statementLinkAccess.GetStatementLink(nextLinkID, ConversationPackage.StatementLinks);
            var statements =
                statmentAccess.GetStatementsInStatementLink(nextLink, ConversationPackage.Statements);
            var actor =
                actorAccess.GetActor(nextLinkID, ConversationPackage.Actors);

            var result = new ConversationResult();
            result.CurrentStatementLink = nextLink;
            result.Statements = statements;
            result.CurrentActor = actor;

            return result;
        }
    }
}