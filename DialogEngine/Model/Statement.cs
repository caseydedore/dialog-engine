using System.Xml.Serialization;

namespace DialogEngine.Model
{
    [XmlRoot]
    public class Statement
    {
        [XmlAttribute]
        public uint ID { get; set; }
        [XmlElement]
        public string Dialog { get; set; }
    }
}
