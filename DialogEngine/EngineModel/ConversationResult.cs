using DialogEngine.Model;
using System.Collections.Generic;

namespace DialogEngine.EngineModel
{
    public class ConversationResult
    {
        public ConversationStatus Status { get; private set; }
        public Actor CurrentActor { get; set; }
        public StatementLink CurrentStatementLink { get; set; }
        public List<Statement> Statements { get; set; }


        public ConversationResult(ConversationStatus status)
        {
            Status = status;
        }
    }
}
