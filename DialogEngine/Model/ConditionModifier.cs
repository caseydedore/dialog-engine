using System.Xml.Serialization;

namespace DialogEngine.Model
{
    public class ConditionModifier
    {
        [XmlAttribute("ConditionName")]
        public string Name { get; set; }
        [XmlText]
        public int Value { get; set; }
    }
}
