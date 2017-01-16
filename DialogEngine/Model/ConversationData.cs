using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogEngine.Model
{
    [XmlRoot]
    public class ConversationData
    {
        [XmlElement]
        public Conversation Conversation { get; set; }
        [XmlElement]
        public List<Actor> Actors { get; set; }
        [XmlElement]
        public List<StatementLink> StatementLinks { get; set; }
        [XmlElement]
        public List<Statement> Statements { get; set; }
        [XmlElement]
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
