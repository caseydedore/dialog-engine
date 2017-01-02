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
        public List<Links> Links { get; set; }
    }

    public class Links
    {
        [XmlAttribute]
        public uint StatementID { get; set; }
        [XmlAttribute]
        public uint NextLinkID { get; set; }
        [XmlAttribute]
        public string Condition { get; set; }
    }
}
