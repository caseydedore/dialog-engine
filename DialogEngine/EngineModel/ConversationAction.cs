using DialogEngine.Model;
using System.Collections.Generic;

namespace DialogEngine.EngineModel
{
    public class ConversationAction
    {
        public StatementLink CurrentStatementLink { get; set; }
        public Statement ChosenStatement { get; set; }
    }
}
