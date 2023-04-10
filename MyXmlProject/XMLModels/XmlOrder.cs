using MyXmlProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyXmlProject.XMLModels
{
    public  class XmlOrder
    {
        [XmlElement("no")]
        public int Id { get; set; }
        [XmlElement("reg_date")]
        public DateTime Date { get; set; }

        [XmlElement("sum")]
        public double Sum { get; set; }
        [XmlElement("user")]
        public XmlUser User { get; set; }
        [XmlElement("product")]
        public List<XmlProduct> Products { get; set; }
    }
}
