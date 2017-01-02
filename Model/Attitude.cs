using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogEngine.Model
{
    [XmlRoot]
    public class Attitudes
    {
        [XmlElement("Attitude")]
        public List<Attitude> Values { get; set; }
    }

    public class Attitude
    {
        [XmlAttribute]
        public uint ID { get; set; }
        [XmlAttribute]
        public int Value { get; set; }
        [XmlText]
        public string Name { get; set; }
    }
}
