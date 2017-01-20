using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogEngine.Model
{
    [XmlRoot]
    public class StatementLink
    {
        [XmlAttribute]
        public uint ID { get; set; }
        [XmlAttribute]
        public uint ActorID { get; set; }
        [XmlElement("Link")]
        public List<Link> Links { get; set; }

        
        public StatementLink()
        {
            Links = new List<Link>();
        }
    }

    public class Link
    {
        [XmlAttribute]
        public uint StatementID { get; set; }
        [XmlAttribute]
        public uint NextLinkID { get; set; }
        [XmlElement("Requirement")]
        public List<ConditionRequirement> Requirements { get; set; } 
        [XmlElement("Modifier")]
        public List<ConditionModifier> Modifiers { get; set; }

        
        public Link()
        {
            Requirements = new List<ConditionRequirement>();
            Modifiers = new List<ConditionModifier>();
        }
    }
}
