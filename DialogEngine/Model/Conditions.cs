using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DialogEngine.Model
{
    [XmlRoot]
    public class Conditions
    {
        [XmlElement("Condition")]
        public List<Condition> Items { get; set; }
    }
}
