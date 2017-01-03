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

        public ConversationResult Advance(ConversationAction Action)
        {
            var nextLinkID = 
                statementLinkAccess.GetStatementLinkByStatementID(Action.CurrentStatementLink, Action.ChosenStatement.ID);
            var nextLink = 
                statementLinkAccess.GetStatementLinkByID(ConversationPackage.StatementLinks, nextLinkID);
            var statements = 
                statmentAccess.GetStatementsInStatementLink(nextLink, ConversationPackage.Statements);

            var result = new ConversationResult();
            result.CurrentStatementLink = nextLink;
            result.Statements = statements;
            //needs actor

            return result;
        }
    }
}