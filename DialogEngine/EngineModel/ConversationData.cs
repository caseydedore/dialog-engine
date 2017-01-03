using DialogEngine.Model;
using System.Collections.Generic;

namespace DialogEngine.EngineModel
{
    public class ConversationData
    {
        public Conversation Conversation { get; set; }
        public List<Actor> Actors { get; set; }
        public List<StatementLink> StatementLinks { get; set; }
        public List<Statement> Statements { get; set; }
        public List<Attitude> Attitudes { get; set; }
    }
}
