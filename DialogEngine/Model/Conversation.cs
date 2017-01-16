using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogEngine.Model
{
    [XmlRoot]
    public class Conversation
    {
        [XmlAttribute]
        public uint ID { get; set; }
        [XmlAttribute]
        public uint StatementLinkID { get; set; }
        [XmlArray("Actor")]
        public List<Actor> Actors { get; set; }

        public Conversation()
        {
            Actors = new List<Actor>();
        }
    }
}
