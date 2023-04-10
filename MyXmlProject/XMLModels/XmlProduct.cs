using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyXmlProject.XMLModels
{
    public  class XmlProduct
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("quantity")]
        public int Count { get; set; }
        [XmlElement("price")]
        public double Price { get; set; }
    }
}
