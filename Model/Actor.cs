using System.Xml.Serialization;

namespace DialogEngine.Model
{
    [XmlRoot]
    public class Actor
    {
        [XmlAttribute]
        public uint ID { get; set; }
        [XmlText]
        public string Name { get; set; }
    }
}
