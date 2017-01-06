using DialogEngine.Model;
using System.Collections.Generic;

namespace DialogEngine.EngineModel
{
    public class ConversationResult
    {
        public Actor CurrentActor { get; set; }
        public StatementLink CurrentStatementLink { get; set; }
        public List<Statement> Statements { get; set; }
        public List<string> NextTurnConditions { get; set; }
    }
}
