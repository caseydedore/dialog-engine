using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogEngine.Model
{
    [XmlRoot]
    public class StatementLink
    {
        [XmlAttribute]
        public uint ID { get; set; }
        [XmlElement("Link")]
        public List<Link> Links { get; set; }
    }

    public class Link
    {
        [XmlAttribute]
        public uint StatementID { get; set; }
        [XmlAttribute]
        public uint NextLinkID { get; set; }
        [XmlAttribute]
        public string Condition { get; set; }
    }
}
