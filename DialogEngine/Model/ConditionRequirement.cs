using System.Xml.Serialization;

namespace DialogEngine.Model
{
    public class ConditionRequirement
    {
        [XmlAttribute("ConditionName")]
        public string Name { get; set; }
        [XmlAttribute]
        public string Operator { get; set; }
        [XmlText]
        public int Value { get; set; }
    }
}
