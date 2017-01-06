using System.Collections.Generic;
using System.Xml.Serialization;

namespace DialogEngine.Model
{
    [XmlRoot]
    public class Condition
    {
        [XmlAttribute]
        public uint ID { get; set; }
        [XmlElement]
        public List<ConditionClause> Clauses { get; set; }


        public Condition()
        {
            Clauses = new List<ConditionClause>();
        }
    }

    public class ConditionClause
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlText]
        public int Value { get; set; }
    }
}
