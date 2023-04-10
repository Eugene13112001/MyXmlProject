using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MyXmlProject.XMLModels
{
    public class XmlUser
    {
        [XmlElement("fio")]
        public string Name { get; set; }
        [XmlElement("email")]
        public string Email { get; set; }

    }
}
