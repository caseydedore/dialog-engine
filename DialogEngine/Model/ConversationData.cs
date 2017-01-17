using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogEngine.Model
{
    [XmlRoot]
    public class Conversation
    {
        [XmlAttribute]
        public uint StartingStatementLinkID { get; set; }
        [XmlArray]
        public List<Actor> Actors { get; set; }
        [XmlArray]
        public List<StatementLink> StatementLinks { get; set; }
        [XmlArray]
        public List<Statement> Statements { get; set; }
        [XmlArray]
        public List<Condition> Conditions { get; set; }


        public Conversation()
        {
            Actors = new List<Actor>();
            StatementLinks = new List<StatementLink>();
            Statements = new List<Statement>();
            Conditions = new List<Condition>();
        }
    }
}
