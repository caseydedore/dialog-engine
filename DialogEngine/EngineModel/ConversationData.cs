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
        public List<Condition> Conditions { get; set; }


        public ConversationData()
        {
            Actors = new List<Actor>();
            StatementLinks = new List<StatementLink>();
            Statements = new List<Statement>();
            Conditions = new List<Condition>();
        }
    }
}
