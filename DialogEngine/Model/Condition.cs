using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DialogEngine.Model
{
    public class Condition
    {
        [XmlAttribute]
        public string Name { get; set; }
        [XmlAttribute]
        public int Max { get; set; }
        [XmlAttribute]
        public int Min { get; set; }
        [XmlText]
        public int Value { get; set; }
    }
}
