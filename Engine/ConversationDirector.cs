using DialogEngine.Data;
using DialogEngine.EngineModel;
using DialogEngine.Model;
using System.Collections.Generic;
using System.Linq;

namespace DialogEngine.Engine
{
    public class ConversationDirector
    {
        private StatementLinkAccess StatementLinkAccess { get; set; }

        private ConversationPackage ConversationPackage { get; set; }

        private StatementLink CurrentStatementLink { get; set; }


        public ConversationDirector()
        {
            StatementLinkAccess = new StatementLinkAccess();
        }

        public void Start(ConversationPackage package)
        {
            ConversationPackage = package;
            CurrentStatementLink = GetStatementLinkByID(ConversationPackage.Conversation.StatementLinkID);
        }

        public void Advance(Statement ChosenStatement)
        {
            var nextLinkID = StatementLinkAccess.GetStatementLinkByStatementID(CurrentStatementLink, ChosenStatement.ID);
            var nextLink = StatementLinkAccess.GetStatementLinkByID(ConversationPackage.StatementLinks, nextLinkID);
            //analyze current statementlink, determine options, actor, ect
            //get the active actor
            //get the active/available statements
        }

        public void End()
        {

        }

        public StatementLink GetStatementLinkByID(uint Id)
        {
            return null;
        }

        public Actor GetActorByID(uint Id)
        {
            return null;
        }
    }
}